using RabbitMQ.Client;
using Newtonsoft.Json;
using System.Text;

namespace Producer.RabbitMQ
{
    public class RabbitMQService
    {
        public void SendMessage(object obj)
        {
            var messageObj = JsonConvert.SerializeObject(obj);
            SendMessage(messageObj);
        }

        public string SendMessage(string message)
        {
            string resultMessage = "Сообщение отправлено!";

            ConnectionFactory factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.BasicAcks += (sender, ea) =>
                {
                    string filePath = @"C:\Users\dns\Desktop\MessagesRabbitMQ\Content.txt";

                    File.AppendAllLines(filePath, new List<string>() { "Сообщение Ack!" });
                };

                channel.BasicNacks += (sender, ea) =>
                {
                    string filePath = @"C:\Users\dns\Desktop\MessagesRabbitMQ\Content.txt";

                    File.AppendAllLines(filePath, new List<string>() { "Сообщение Nack!" });
                };

                channel.QueueDeclare("MyQueue", false, false, false, null);

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish("", "MyQueue", null, body);

                return resultMessage;
            }
        }
    }
}
