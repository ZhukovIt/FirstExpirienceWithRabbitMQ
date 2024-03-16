using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogMessageReviewer
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string connectionStringName = "LogMessageReviewer.Properties.Settings.RabbitMQConnectionString";
            string connectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
            using (UnitOfWork unitOfWork = new UnitOfWork(connectionString))
            {
                Application.Run(new MainForm(unitOfWork));
            }
        }
    }
}
