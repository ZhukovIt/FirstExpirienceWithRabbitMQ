using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;

namespace ProducerLogic.LogMessages
{
    public class LogMessage : Entity
    {
        private string _externalId;

        public virtual Guid ExternalId
        {
            get => new Guid(_externalId);
            set => _externalId = value.ToString();
        }

        public virtual LogMessageStatus Status { get; protected set; }

        public virtual EventType EventType { get; protected set; }

        public virtual string Content { get; protected set; }

        private string _errorMessage;

        public virtual Maybe<string> ErrorMessage
        {
            get => _errorMessage;
            set => _errorMessage = value.HasValue ? value.Value : null;
        }

        protected LogMessage()
        {

        }

        public LogMessage(Guid externalId, LogMessageStatus status, EventType eventType, string content, Maybe<string> errorMessage)
        {
            ExternalId = externalId;
            Status = status ?? throw new ArgumentNullException(nameof(status));
            EventType = eventType ?? throw new ArgumentNullException(nameof(eventType));
            Content = content ?? throw new ArgumentNullException(nameof(content));
            ErrorMessage = errorMessage;
        }

        public virtual void MessageIsDelivered()
        {
            Status = LogMessageStatus.Success;
            ErrorMessage = Maybe.None;
        }

        public virtual void MessageIsNotDelivered(string message)
        {
            Status = LogMessageStatus.Failure;
            ErrorMessage = message;
        }
    }
}
