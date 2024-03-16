using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducerLogic.LogMessages
{
    public class LogMessageStatusMap : ClassMap<LogMessageStatus>
    {
        public LogMessageStatusMap() 
        {
            Id(x => x.Id);

            Map(x => x.Name).CustomType<string>().Length(100);
        }
    }
}
