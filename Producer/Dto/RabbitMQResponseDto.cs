using CSharpFunctionalExtensions;

namespace Producer.Dto
{
    public class RabbitMQResponseDto
    {
        public string ExternalId { get; set; }

        public bool HandleResult { get; set; }

        public string? ErrorMessage { get; set; }
    }
}
