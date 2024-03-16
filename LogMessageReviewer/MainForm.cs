using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogMessageReviewer
{
    public partial class MainForm : Form
    {
        private readonly UnitOfWork _unitOfWork;

        public MainForm(UnitOfWork unitOfWork)
        {
            InitializeComponent();

            _unitOfWork = unitOfWork;
            unitOfWork.Load();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            bsEventType.DataSource = _unitOfWork.CreateEventTypeDataView();
            bsLogMessageStatus.DataSource = _unitOfWork.CreateLogMessageStatusDataView();
            bsLogMessage.DataSource = _unitOfWork.CreateLogMessageDataView();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _unitOfWork.Load();
        }
    }
}
