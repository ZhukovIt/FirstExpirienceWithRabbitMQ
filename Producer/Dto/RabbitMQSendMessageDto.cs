namespace Producer.Dto
{
    public class RabbitMQSendMessageDto
    {
        public string ExternalId { get; set; }

        public string EventName { get; set; }

        public string Content { get; set; }
    }
}
