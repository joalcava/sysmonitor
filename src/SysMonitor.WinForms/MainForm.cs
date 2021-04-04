using SysMonitor.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysMonitor.WinForms
{
    public partial class MainForm : Form
    {
        private readonly SystemMonitor SystemMonitor;

        public MainForm()
        {
            ISystemDataReader systemDataReader;
            switch (Environment.OSVersion.Platform)
            {
                case PlatformID.Win32NT:
                    systemDataReader = new WindowsSystemDataReader();
                    break;
                case PlatformID.Unix:
                    systemDataReader = new LinuxSystemDataReader();
                    break;
                default:
                    throw new PlatformNotSupportedException();
            }


            SystemMonitor = new SystemMonitor(systemDataReader);
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var currentCultureName = System.Threading.Thread.CurrentThread.CurrentUICulture.Name;

            if (currentCultureName.StartsWith("es"))
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
                this.Controls.Clear();
                InitializeComponent();
                SetPrevData();
            }
            else if (currentCultureName.StartsWith("en"))
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("es");
                this.Controls.Clear();
                InitializeComponent();
                SetPrevData();
            }
        }

        public void SetPrevData()
        {
            if (this.SystemMonitor.LastRead != null)
            {
                this.DataLbl.Text = MonitoringDataStringBuilder.Build(SystemMonitor.LastRead);
            }
        }

        private void GetDataBtn_Click(object sender, EventArgs e)
        {
            var data = SystemMonitor.GetData();
            var dataLabel = MonitoringDataStringBuilder.Build(data);
            this.DataLbl.Text = dataLabel;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var location = SystemMonitor.ExportData();
            ExportResultLbl.Text = location;
        }
    }
}
