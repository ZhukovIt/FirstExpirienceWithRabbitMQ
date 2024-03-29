﻿using CSharpFunctionalExtensions;
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

        public Maybe<LogMessage> GetByGuid(string guid)
        {
            return _unitOfWork
                .Query<LogMessage>()
                .Where(x => x.ExternalId.ToString() == guid)
                .FirstOrDefault()
                .AsMaybe();
        }
    }
}
