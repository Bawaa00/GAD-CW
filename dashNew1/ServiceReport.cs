using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace dashNew1
{
    public partial class ServiceReport : MetroFramework.Forms.MetroForm
    {
        public ServiceReport()
        {
            InitializeComponent();
        }

        Connect_DB db = new Connect_DB();

        private void ServiceReport_Load(object sender, EventArgs e)
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

        private void btn_search_Click(object sender, EventArgs e)
        {
            try
            {
                // TODO: This line of code loads data into the 'rENT_VEHICLESDataSet.Vehicle' table. You can move, or remove it, as needed.
                this.ServiceTableAdapter.FillBy(this.DataSet_Service.Service, cmb_lplate.Text);

                this.reportViewerService.RefreshReport();
            }
            catch (SqlException)
            {
                MetroFramework.MetroMessageBox.Show(this, "Database Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            try
            {
                // TODO: This line of code loads data into the 'DataSet_Service.Service' table. You can move, or remove it, as needed.
                this.ServiceTableAdapter.Fill(this.DataSet_Service.Service);

                this.reportViewerService.RefreshReport();
            }
            catch (SqlException)
            {
                MetroFramework.MetroMessageBox.Show(this, "Database Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
