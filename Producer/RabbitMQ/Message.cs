using CSharpFunctionalExtensions;

namespace Producer.RabbitMQ
{
    public class Message : ValueObject
    {
        public string Value { get; }

        private Message(string message)
        {
            Value = message;
        }

        public static Result<Message> Create(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                return Result.Failure<Message>("Значение message является обязательным!");

            return Result.Success(new Message(message));
        }

        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            yield return Value;
        }

        public static implicit operator string(Message message)
        {
            return message.Value;
        }

        public static explicit operator Message(string message)
        {
            return Create(message).Value;
        }
    }
}
