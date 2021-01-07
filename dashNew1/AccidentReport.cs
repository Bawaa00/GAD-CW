using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dashNew1
{
    public partial class AccidentReport : MetroFramework.Forms.MetroForm
    {
        public AccidentReport()
        {
            InitializeComponent();
        }

        private void AccidentReport_Load(object sender, EventArgs e)
        {

            this.reportViewerAcc.RefreshReport();
        }
    }
}
