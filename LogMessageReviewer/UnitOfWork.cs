using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogMessageReviewer
{
    public class UnitOfWork : IDisposable
    {
        private readonly SqlConnection _sqlConnection;
        private readonly dtsOSAEvent _dtsOSAEvent;
        private readonly dtsOSAEventTableAdapters.LogMessageTableAdapter _taLogMessage;
        private readonly dtsOSAEventTableAdapters.LogMessageStatusTableAdapter _taLogMessageStatus;
        private readonly dtsOSAEventTableAdapters.EventTypeTableAdapter _taEventType;
        private readonly dtsOSAEventTableAdapters.TableAdapterManager _taManager;

        public UnitOfWork(string connectionString)
        {
            _sqlConnection = new SqlConnection(connectionString);
            _sqlConnection.Open();

            _dtsOSAEvent = new dtsOSAEvent();

            _taLogMessage = new dtsOSAEventTableAdapters.LogMessageTableAdapter();
            _taLogMessage.Connection = _sqlConnection;

            _taLogMessageStatus = new dtsOSAEventTableAdapters.LogMessageStatusTableAdapter();
            _taLogMessageStatus.Connection = _sqlConnection;

            _taEventType = new dtsOSAEventTableAdapters.EventTypeTableAdapter();
            _taEventType.Connection = _sqlConnection;

            _taManager = new dtsOSAEventTableAdapters.TableAdapterManager();
            _taManager.LogMessageTableAdapter = _taLogMessage;
            _taManager.LogMessageStatusTableAdapter = _taLogMessageStatus;
            _taManager.EventTypeTableAdapter = _taEventType;

            LoadReferenceData();
        }

        private void LoadReferenceData()
        {
            _taLogMessageStatus.Fill(_dtsOSAEvent.LogMessageStatus);
            _taEventType.Fill(_dtsOSAEvent.EventType);
        }

        public DataView CreateEventTypeDataView()
        {
            DataView dv = new DataView(_dtsOSAEvent.EventType);
            return dv;
        }

        public DataView CreateLogMessageStatusDataView()
        {
            DataView dv = new DataView(_dtsOSAEvent.LogMessageStatus);
            return dv;
        }

        public DataView CreateLogMessageDataView()
        {
            DataView dv = new DataView(_dtsOSAEvent.LogMessage);
            return dv;
        }

        public void Load()
        {
            _taLogMessage.Fill(_dtsOSAEvent.LogMessage);
        }

        public void Commit()
        {
            _taLogMessageStatus.Update(_dtsOSAEvent);
            _taEventType.Update(_dtsOSAEvent);
            _taManager.UpdateAll(_dtsOSAEvent);
        }

        public void Dispose()
        {
            _sqlConnection.Close();
            _sqlConnection.Dispose();
        }
    }
}
