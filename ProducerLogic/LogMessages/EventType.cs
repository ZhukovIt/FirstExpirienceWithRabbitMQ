using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducerLogic.LogMessages
{
    public class EventType : Entity
    {
        public static readonly EventType CreateUser = new(1, "Создание пользователя");
        public static readonly EventType UpdateUser = new(2, "Редактирование пользователя");

        public virtual string Name { get; protected set; }

        protected EventType()
        {

        }

        private EventType(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
