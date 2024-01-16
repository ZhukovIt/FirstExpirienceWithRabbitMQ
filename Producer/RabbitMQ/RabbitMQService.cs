using RabbitMQ.Client;
using Newtonsoft.Json;
using System.Text;

namespace Producer.RabbitMQ
{
    public class RabbitMQService : IRabbitMQService
    {
        public void SendMessage(object obj)
        {
            var messageObj = JsonConvert.SerializeObject(obj);
            SendMessage(messageObj);
        }

        public void SendMessage(string message)
        {
            ConnectionFactory factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare("MyQueue", false, false, false, null);

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish("", "MyQueue", null, body);
            }
        }
    }
}
