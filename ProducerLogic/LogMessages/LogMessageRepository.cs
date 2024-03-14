using ProducerLogic.Common;
using ProducerLogic.Utils;

namespace ProducerLogic.LogMessages
{
    public class LogMessageRepository : Repository<LogMessage>
    {
        public LogMessageRepository(UnitOfWork _unitOfWork)
            : base(_unitOfWork)
        {

        }
    }
}
