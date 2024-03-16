using FluentValidation;

namespace Producer.Dto
{
    public class PublishEventDto
    {
        public string EventType { get; set; }

        public object Content { get; set; }
    }

    public class PublishEventValidation : AbstractValidator<PublishEventDto>
    {
        public PublishEventValidation() 
        {
            RuleFor(x => x.EventType).NotEmpty().WithMessage("EventType является обязательным!");
            RuleFor(x => x.Content).NotEmpty();
        }
    }
}
