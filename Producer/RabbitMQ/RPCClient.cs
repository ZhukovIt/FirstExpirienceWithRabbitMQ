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

        public RPCClient()
        {
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
            byte[] body = e.Body.ToArray();
            string response = Encoding.UTF8.GetString(body);
        }

        public void SendRPCRequest(Guid correlationGuid, string eventTypeName, string content)
        {
            IBasicProperties props = _channel.CreateBasicProperties();
            props.CorrelationId = correlationGuid.ToString();
            props.ReplyTo = _replyQueueName;

            var dto = new RabbitMQSendMessageDto()
            {
                EventName = eventTypeName,
                Content = content
            };
            string dtoContent = JsonSerializer.Serialize(dto);
            byte[] messageBytes = Encoding.UTF8.GetBytes(dtoContent);
            
            _channel.BasicPublish(exchange: string.Empty,
                                 routingKey: QUEUE_NAME,
                                 basicProperties: props,
                                 body: messageBytes);
        }
    }
}
