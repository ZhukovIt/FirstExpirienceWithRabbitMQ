namespace Producer.Dto
{
    public class RabbitMQSendMessageDto
    {
        public string EventName { get; set; }

        public object Content { get; set; }
    }
}
