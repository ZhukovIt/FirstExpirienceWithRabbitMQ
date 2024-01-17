using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Consumer.RabbitMQ
{
    public class RabbitMQListener : BackgroundService
    {
        private IConnection _connection;
        private IModel _channel;

        public RabbitMQListener()
        {
            ConnectionFactory factory = new ConnectionFactory() { HostName = "localhost" };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare("MyQueue", false, false, false, null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (sender, e) =>
            {
                var content = Encoding.UTF8.GetString(e.Body.ToArray());

                Console.WriteLine($"Получено сообщение: {content}");

                _channel.BasicAck(e.DeliveryTag, false);
            };

            _channel.BasicConsume("MyQueue", false, consumer);

            return Task.CompletedTask;
        }

        public override void Dispose()
        {
            _connection.Dispose();
            _channel.Dispose();
            base.Dispose();
        }
    }
}
