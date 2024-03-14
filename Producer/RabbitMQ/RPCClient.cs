using System.Collections.Concurrent;
using System.Text;
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
        private readonly ConcurrentDictionary<string, TaskCompletionSource<string>> _callbackMapper = new ();

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
            if (!_callbackMapper.TryRemove(e.BasicProperties.CorrelationId, out var taskCompletionSource))
                return;

            byte[] body = e.Body.ToArray();
            string response = Encoding.UTF8.GetString(body);
            taskCompletionSource.TrySetResult(response);
        }

        public Task<string> SendRPCRequestAsync(string message, CancellationToken cancellationToken = default)
        {
            string correlationId = Guid.NewGuid().ToString();
            IBasicProperties props = _channel.CreateBasicProperties();
            props.CorrelationId = correlationId;
            props.ReplyTo = _replyQueueName;

            byte[] messageBytes = Encoding.UTF8.GetBytes(message);

            var taskCompletionSource = new TaskCompletionSource<string>();
            _callbackMapper.TryAdd(correlationId, taskCompletionSource);

            _channel.BasicPublish(exchange: string.Empty,
                                 routingKey: QUEUE_NAME,
                                 basicProperties: props,
                                 body: messageBytes);

            cancellationToken.Register(() => _callbackMapper.TryRemove(correlationId, out _));
            return taskCompletionSource.Task;
        }
    }
}
