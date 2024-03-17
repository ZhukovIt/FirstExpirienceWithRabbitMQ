using ProducerLogic.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducerTests.Integrations
{
    public static class ConnectDBProvider
    {
        private static readonly string _connectionString = "Server=AK-127NB;Database=RabbitMQ;User id=main_sa;Password=Developer4323;";
        private static readonly SessionFactory _sessionFactory = new SessionFactory(_connectionString);

        public static UnitOfWork CreateUnitOfWork()
        {
            return new UnitOfWork(_sessionFactory);
        }
    }
}
