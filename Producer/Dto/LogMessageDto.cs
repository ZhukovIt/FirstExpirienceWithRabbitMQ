namespace Producer.Dto
{
    public class LogMessageDto
    {
        public long Id { get; set; }

        public string ExternalId { get; set; }

        public string Status { get; set; }

        public string EventType { get; set; }

        public string Content { get; set; }

        public string? ErrorMessage { get; set; }
    }
}
