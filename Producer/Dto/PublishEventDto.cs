using FluentValidation;

namespace Producer.Dto
{
    public class PublishEventDto
    {
        public string EventType { get; set; }

        public object Content { get; set; }
    }
}
