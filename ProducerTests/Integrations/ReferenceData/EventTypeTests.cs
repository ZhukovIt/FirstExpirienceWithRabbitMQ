using ProducerLogic.LogMessages;
using ProducerLogic.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProducerTests.Integrations.ReferenceData
{
    public class EventTypeTests
    {
        [Fact]
        public void All_requires_values_are_in_DB()
        {
            Verify(1, EventType.CreateUser);
            Verify(2, EventType.UpdateUser);
        }

        private void Verify(int eventTypeId, EventType hardCodedEventType)
        {
            using (UnitOfWork unitOfWork = ConnectDBProvider.CreateUnitOfWork())
            {
                var repository = new EventTypeRepository(unitOfWork);
                EventType eventType = repository.GetById(eventTypeId).Value;

                Assert.Equal(eventType.Id, hardCodedEventType.Id);
                Assert.Equal(eventType.Name, hardCodedEventType.Name);
            }
        }
    }
}
