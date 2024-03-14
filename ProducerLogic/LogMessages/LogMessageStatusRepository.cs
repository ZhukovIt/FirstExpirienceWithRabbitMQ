using ProducerLogic.Common;
using ProducerLogic.Utils;

namespace ProducerLogic.LogMessages
{
    public class LogMessageStatusRepository : Repository<LogMessageStatus>
    {
        public LogMessageStatusRepository(UnitOfWork _unitOfWork)
            : base(_unitOfWork)
        {

        }
    }
}
