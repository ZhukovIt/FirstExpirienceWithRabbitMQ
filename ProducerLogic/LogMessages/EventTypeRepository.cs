using CSharpFunctionalExtensions;
using ProducerLogic.Common;
using ProducerLogic.Utils;

namespace ProducerLogic.LogMessages
{
    public class EventTypeRepository : Repository<EventType>
    {
        public EventTypeRepository(UnitOfWork unitOfWork) 
            : base(unitOfWork) 
        {

        }

        public Maybe<EventType> GetByName(string eventTypeName)
        {
            return _unitOfWork
                .Query<EventType>()
                .Where(x => x.Name == eventTypeName)
                .FirstOrDefault()
                .AsMaybe();
        }
    }
}
