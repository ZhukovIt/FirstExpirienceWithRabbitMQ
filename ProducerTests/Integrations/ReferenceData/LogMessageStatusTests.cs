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
    public class LogMessageStatusTests
    {
        [Fact]
        public void All_requires_values_are_in_DB()
        {
            Verify(1, LogMessageStatus.InProgress);
            Verify(2, LogMessageStatus.Success);
            Verify(3, LogMessageStatus.Failure);
        }

        private void Verify(int statusId, LogMessageStatus hardCodedStatus)
        {
            using (UnitOfWork unitOfWork = ConnectDBProvider.CreateUnitOfWork())
            {
                var repository = new LogMessageStatusRepository(unitOfWork);
                LogMessageStatus status = repository.GetById(statusId).Value;

                Assert.Equal(status.Id, hardCodedStatus.Id);
                Assert.Equal(status.Name, hardCodedStatus.Name);
            }
        }
    }
}
