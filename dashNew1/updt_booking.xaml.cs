using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;

namespace dashNew1
{
    /// <summary>
    /// Interaction logic for updt_booking.xaml
    /// </summary>
    public partial class updt_booking : Window
    {
        public updt_booking()
        {
            InitializeComponent();
        }
        Connect_DB db = new Connect_DB();

        private void form_up_booking_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = db.getData("select * from Booking");
            cmb_bid.ItemsSource = dt.DefaultView;
            cmb_bid.DisplayMemberPath = "BK_No";
            cmb_bid.SelectedValuePath = "BK_No";

            dt = db.getData("select * from Vehicle");
            cmb_vid.ItemsSource = dt.DefaultView;
            cmb_vid.DisplayMemberPath = "L_Plate";
            cmb_vid.SelectedValuePath = "L_Plate";

            dt = db.getData("select * from Customer");
            cmb_cid.ItemsSource = dt.DefaultView;
            cmb_cid.DisplayMemberPath = "Cus_ID";
            cmb_cid.SelectedValuePath = "Cus_ID";

            dt = db.getData("select * from Driver");
            cmb_did.ItemsSource = dt.DefaultView;
            cmb_did.DisplayMemberPath = "D_ID";
            cmb_did.SelectedValuePath = "D_ID";
        }

        private void cmb_bid_DropDownClosed(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = db.getData("exec booking_vehicle '" + cmb_bid.Text + "'");
            date_book.Text = dt.Rows[0][1].ToString();
            date_pick.Text = dt.Rows[0][2].ToString();
            date_lend.Text = dt.Rows[0][3].ToString();
            cmb_cid.Text = dt.Rows[0][4].ToString();
            txt_fname.Text = dt.Rows[0][5].ToString();
            txt_lname.Text = dt.Rows[0][6].ToString();
            cmb_vid.Text = dt.Rows[0][7].ToString();
            txt_make.Text = dt.Rows[0][8].ToString();
            txt_model.Text = dt.Rows[0][9].ToString();
            cmb_did.Text = dt.Rows[0][10].ToString();
            txt_dname.Text = dt.Rows[0][11].ToString();
        }

        private void btn_add_cus_Click(object sender, RoutedEventArgs e)
        {
            addCustomer obj = new addCustomer();
            obj.Show();
        }

        private void btn_view_Click(object sender, RoutedEventArgs e)
        {
            Update_Vehicle obj = new Update_Vehicle();
            obj.Show();
        }

        private void btn_view_driver_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
           
            string a = " update Booking set  BK_date = '"+date_book.Text+"', S_date='"+date_pick.Text+"', L_date='"+date_lend.Text+ "' where BK_No = '" + cmb_bid.Text + "'";
            string b = " update Car_Booking set VNO='" + cmb_vid.Text + "' , DNO = '" + cmb_did.Text + "' , BNO = '"+cmb_bid.Text+ "' where  CNO = '" + cmb_cid.Text + "'";

            int x = db.save_update_delete(a);
            int y = db.save_update_delete(b);
            if (x == 1 && y == 1 )
            {
                Messagebox msg = new Messagebox();
                msg.informationMsg("Data Updated Successfully!");
                msg.Show();
                btn_bill.Visibility = Visibility.Visible;
            }
            else
            {
                Messagebox msg = new Messagebox();
                msg.errorMsg("Unable to Update Data.Please check again");
                msg.Show();
            }
        }

        private void cmb_cid_DropDownClosed(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = db.getData("select * from Customer where Cus_ID='" + cmb_cid.Text + "'");
            txt_fname.Text = dt.Rows[0][1].ToString();
            txt_lname.Text = dt.Rows[0][2].ToString();
        }

        private void cmb_vid_DropDownClosed(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = db.getData("select * from Vehicle where L_Plate='" + cmb_vid.Text + "'");
            txt_make.Text = dt.Rows[0][2].ToString();
            txt_model.Text = dt.Rows[0][3].ToString();
        }

        private void cmb_did_DropDownClosed(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = db.getData("select * from Driver where D_ID = '" + cmb_did.Text + "'");
            txt_dname.Text = dt.Rows[0][2].ToString();
        }

        private void btn_home_Click(object sender, RoutedEventArgs e)
        {
            MainWindow obj = new MainWindow();
            obj.Show();
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_bill_Click(object sender, RoutedEventArgs e)
        {
            BillPrint obj = new BillPrint();
            obj.txt_bkid.Text = this.cmb_bid.Text;
            obj.txt_bkdate.Text = this.date_book.Text;
            obj.txt_cusid.Text = this.cmb_cid.Text;
            obj.txt_fname.Text = this.txt_fname.Text;
            obj.txt_sname.Text = this.txt_lname.Text;
            obj.txt_did.Text = this.cmb_did.Text;
            obj.txt_dname.Text = this.txt_dname.Text;
            obj.txt_dt_lend.Text = this.date_lend.Text;
            obj.txt_dt_pick.Text = this.date_pick.Text;
            obj.txt_lplate.Text = this.cmb_vid.Text;
            obj.txt_make.Text = this.txt_make.Text;
            obj.txt_model.Text = this.txt_model.Text;
            obj.Show();
        }
    }
}
