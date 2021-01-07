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

        Connect_DB db = new Connect_DB();

        private void AccidentReport_Load(object sender, EventArgs e)
        {
            DataRow dr;
            DataTable dt = new DataTable();
            dt = db.getData("select * from Vehicle");
            dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            cmb_lplate.ValueMember = "L_Plate";

            cmb_lplate.DisplayMember = "L_Plate";
            cmb_lplate.DataSource = dt;
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet_Service.Acc_repair' table. You can move, or remove it, as needed.
            this.Acc_repairTableAdapter.Fill(this.DataSet_Service.Acc_repair);

            this.reportViewerAcc.RefreshReport();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            this.Acc_repairTableAdapter.FillBy(this.DataSet_Service.Acc_repair, cmb_lplate.Text);
            this.reportViewerAcc.RefreshReport();
        }
    }
}
