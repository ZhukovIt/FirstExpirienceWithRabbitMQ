using System.Diagnostics;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RPC_First
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Сервер RPC успешно запущен!");

            var factory = new ConnectionFactory() { HostName = "localhost" };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.QueueDeclare(
                queue: "rpc_queue",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);
            channel.BasicQos(
                prefetchSize: 0,
                prefetchCount: 1,
                global: false);

            var consumer = new EventingBasicConsumer(channel);
            channel.BasicConsume(
                queue: "rpc_queue",
                autoAck: false,
                consumer: consumer);
            Console.WriteLine("Сервер ожидает RPC запросы");

            consumer.Received += (model, ea) =>
            {
                string response = string.Empty;

                byte[] body = ea.Body.ToArray();
                var props = ea.BasicProperties;
                var replyRrops = channel.CreateBasicProperties();
                replyRrops.CorrelationId = props.CorrelationId;

                try
                {
                    string message = Encoding.UTF8.GetString(body);
                    int n = int.Parse(message);
                    Console.WriteLine($"Пришло следующее сообщение для обработки: {message}");
                    double milliSeconds = Math.Round(Fib(n) * 1060 / Fib(40), 3);
                    response = ConvertTime(milliSeconds);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Обработка сообщения не удалась.\r\nТекст ошибки: {ex.Message}");
                    response = string.Empty;
                }
                finally
                {
                    byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                    channel.BasicPublish(
                        exchange: string.Empty,
                        routingKey: props.ReplyTo,
                        basicProperties: replyRrops,
                        body: responseBytes);
                    channel.BasicAck(
                        deliveryTag: ea.DeliveryTag,
                        multiple: false);
                }
            };

            Console.WriteLine("Нажмите Enter для отключения сервера!");
            Console.ReadLine();
        }

        private static double Fib(int n)
        {
            double baseExp = (1 + Math.Sqrt(5)) / 2;
            return Math.Pow(baseExp, n);
        }

        private static int FibFact(int n)
        {
            if (n is 0 or 1)
                return n;

            return FibFact(n - 1) + FibFact(n - 2);
        }

        private static string ConvertTime(double milliSecond)
        {
            if (milliSecond < 1000)
                return $"{milliSecond} миллисекунд";

            long seconds = (long)(milliSecond / 1000);
            if (seconds < 60)
                return $"{seconds} секунд и {milliSecond % 1000} миллисекунд";

            long minutes = seconds / 60;
            if (minutes < 60)
                return $"{minutes} минут и {seconds % 60} секунд";

            long hours = minutes / 60;
            if (hours < 24)
                return $"{hours} часов и {minutes % 60} минут";

            long days = hours / 24;
            if (days < 30)
                return $"{days} дней и {hours % 24} часов";

            long months = days / 30;
            if (months < 12)
                return $"{months} месяцев и {days % 30} дней";

            long years = months / 12;
            return $"{years} лет и {years % 12} месяцев";
        }
    }
}
