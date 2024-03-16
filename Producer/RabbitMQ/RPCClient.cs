using System.Collections.Concurrent;
using System.Text;
using System.Text.Json;
using CSharpFunctionalExtensions;
using Producer.Dto;
using ProducerLogic.LogMessages;
using ProducerLogic.Utils;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;

namespace Producer.RabbitMQ
{
    public class RPCClient
    {
        public const string QUEUE_NAME = "Server_OSA_Queue";

        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly string _replyQueueName;
        private readonly SessionFactory _sessionFactory;

        public RPCClient(SessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;

            ConnectionFactory factory = new ConnectionFactory() { HostName = "localhost" };
            try
            {
                _connection = factory.CreateConnection();
            }
            catch (BrokerUnreachableException ex)
            {
                List<Exception> exceptions = new List<Exception>();
                Exception currentException = ex;
                while (currentException.InnerException != null)
                {
                    exceptions.Add(currentException);
                    currentException = currentException.InnerException;
                }

                if (exceptions.Any(x => x.Message == "Connection failed"))
                    throw new InvalidOperationException("Сервер RabbitMQ не запущен!");

                throw;
            }

            _channel = _connection.CreateModel();

            _channel.QueueDeclare(
                queue: QUEUE_NAME,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            _channel.BasicQos(
                prefetchSize: 0,
                prefetchCount: 1,
                global: false);

            _replyQueueName = _channel.QueueDeclare().QueueName;
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += RabbitMQConsumer_Received;

            _channel.BasicConsume(
                consumer: consumer,
                queue: _replyQueueName,
                autoAck: true);
        }

        private void RabbitMQConsumer_Received(object? sender, BasicDeliverEventArgs e)
        {
            byte[] responseBytes = e.Body.ToArray();
            string responseContent = Encoding.UTF8.GetString(responseBytes);
            var response = JsonSerializer.Deserialize<RabbitMQResponseDto>(responseContent);
            if (response == null || response.ExternalId == null)
                throw new InvalidOperationException("Система работает не корректно!");

            var unitOfWork = new UnitOfWork(_sessionFactory);
            var logMessageRepository = new LogMessageRepository(unitOfWork);

            Maybe<LogMessage> logMessageOrNothing = logMessageRepository.GetByGuid(new Guid(response.ExternalId));
            if (logMessageOrNothing.HasNoValue)
                throw new KeyNotFoundException($"Сообщения с ExternalId = {response.ExternalId} не существует!");

            if (response.HandleResult)
                logMessageOrNothing.Value.MessageIsDelivered();
            else
                logMessageOrNothing.Value.MessageIsNotDelivered(response.ErrorMessage);

            logMessageRepository.Add(logMessageOrNothing.Value);

            unitOfWork.Commit();
        }

        public void SendRPCRequest(Guid correlationGuid, string eventTypeName, string content)
        {
            IBasicProperties props = _channel.CreateBasicProperties();
            props.CorrelationId = correlationGuid.ToString();
            props.ReplyTo = _replyQueueName;

            var dto = new RabbitMQSendMessageDto()
            {
                ExternalId = correlationGuid.ToString(),
                EventName = eventTypeName,
                Content = content
            };
            string dtoContent = JsonSerializer.Serialize(dto);
            byte[] messageBytes = Encoding.UTF8.GetBytes(dtoContent);
            
            _channel.BasicPublish(
                exchange: string.Empty,
                routingKey: QUEUE_NAME,
                basicProperties: props,
                body: messageBytes);
        }
    }
}
