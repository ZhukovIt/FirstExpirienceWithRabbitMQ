using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;

namespace ProducerLogic.LogMessages
{
    public class LogMessageStatus : Entity
    {
        public static readonly LogMessageStatus InProgress = new(1, "В процессе");
        public static readonly LogMessageStatus Success = new(2, "Успешно");
        public static readonly LogMessageStatus Failure = new(3, "Провалилось");

        public virtual string Name { get; protected set; }

        protected LogMessageStatus()
        {

        }

        private LogMessageStatus(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
