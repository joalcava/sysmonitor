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

namespace ArandaSoftware.SysMonitor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
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
            }
            else if (currentCultureName.StartsWith("en"))
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("es");
                this.Controls.Clear();
                InitializeComponent();
            }
        }

        private void GetDataBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
