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
    }
}
