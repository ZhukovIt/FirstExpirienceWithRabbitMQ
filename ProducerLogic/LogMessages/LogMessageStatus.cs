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
        public static readonly LogMessageStatus Delivered = new(2, "Доставлено");
        public static readonly LogMessageStatus NotDelivered = new(3, "Не доставлено");

        public string Name { get; private set; }

        private LogMessageStatus(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
