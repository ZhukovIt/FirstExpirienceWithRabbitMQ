using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Producer.RabbitMQ
{
    public class RabbitMQEnvelope
    {
        public object Body { get; set; }

        public int ResultCode { get; set; }

        public string ErrorMessage { get; set; }

        public DateTime TimeGenerated { get; set; }
    }
}
