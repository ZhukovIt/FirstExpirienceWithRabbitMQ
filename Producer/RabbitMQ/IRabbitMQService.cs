namespace Producer.RabbitMQ
{
    public interface IRabbitMQService
    {
        void SendMessage(object obj);

        void SendMessage(string message);
    }
}
