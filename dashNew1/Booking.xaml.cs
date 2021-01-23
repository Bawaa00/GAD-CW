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
using System.Text.RegularExpressions;

namespace dashNew1
{
    /// <summary>
    /// Interaction logic for Booking.xaml
    /// </summary>
    public partial class Booking : Window
    {
        public Booking()
        {
            InitializeComponent();
        }
        Connect_DB db = new Connect_DB();

        private void form_booking_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = db.getData("select * from Vehicle");
            cmb_vid.ItemsSource = dt.DefaultView;
            cmb_vid.DisplayMemberPath = "L_Plate";
            cmb_vid.SelectedValuePath = "L_Plate";

            dt = db.getData("select * from Customer");
            cmb_cusid.ItemsSource = dt.DefaultView;
            cmb_cusid.DisplayMemberPath = "Cus_ID";
            cmb_cusid.SelectedValuePath = "Cus_ID";

            dt = db.getData("select * from Driver");
            cmb_did.ItemsSource = dt.DefaultView;
            cmb_did.DisplayMemberPath = "D_ID";
            cmb_did.SelectedValuePath = "D_ID";

            date_book.Text = DateTime.Now.ToString();

            DataTable dt2 = new DataTable();
            dt = db.getData("Select max(BK_NO) from Booking ");
            string id = dt.Rows[0][0].ToString();
            var prefix = Regex.Match(id, "^\\D+").Value;
            var number = Regex.Replace(id, "^\\D+", "");
            var i = int.Parse(number) + 1;
            var newString = prefix + i.ToString(new string('0', number.Length));
            txt_bid.Text = newString;

            cmb_cusid.Text = "";
            cmb_vid.Text = "";
            cmb_did.Text = "";
            date_lend.Text = "";
            date_pick.Text = "";
            txt_cusFname.Clear();
            txt_cusLname.Clear();
            txt_dname.Clear();
            txt_make.Clear();
            txt_model.Clear();
        }

        private void btn_submit_Click(object sender, RoutedEventArgs e)

        {
            try
            {
                string query1 = "Insert into Booking values ('" + txt_bid.Text + "','" + date_book.Text + "','" + date_pick.Text + "','" + date_lend.Text + "')";
                string query2 = "Insert into Car_Booking values ('" + cmb_cusid.Text + "','" + cmb_vid.Text + "','" + cmb_did.Text + "','" + txt_bid.Text + "')";

                int i = db.save_update_delete(query1);
                int j = db.save_update_delete(query2);
                if (i == 1 && j == 1)
                {
                    Messagebox msg = new Messagebox();
                    form_booking_Loaded(this, null);
                    btn_bill.Visibility = Visibility.Visible;
                    msg.Show();
                }

                else
                {
                    Messagebox msg = new Messagebox();
                    msg.errorMsg("Sorry, couldn't save your data.Please try again");
                    msg.Show();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            
        }

        private void btn_addcus_Click(object sender, RoutedEventArgs e)
        {
            addCustomer obj = new addCustomer();
            obj.Show();
        }

        private void btn_view_v_Click(object sender, RoutedEventArgs e)
        {
            Update_Vehicle obj = new Update_Vehicle();
            obj.Show();
        }

        private void btn_view_d_Click(object sender, RoutedEventArgs e)
        {
            view_driver obj = new view_driver();
            obj.Show();
        }

        private void btn_home_Click(object sender, RoutedEventArgs e)
        {
            MainWindow obj = new MainWindow();
            this.Close();
            obj.Show();
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void btn_bill_Click(object sender, RoutedEventArgs e)
        {
            BillPrint obj = new BillPrint();
            obj.txt_bkid.Text = this.txt_bid.Text;
            obj.txt_bkdate.Text = this.date_book.Text;
            obj.txt_cusid.Text = this.cmb_cusid.Text;
            obj.txt_fname.Text = this.txt_cusFname.Text;
            obj.txt_sname.Text = this.txt_cusLname.Text;
            obj.txt_did.Text = this.cmb_did.Text;
            obj.txt_dname.Text = this.txt_dname.Text;
            obj.txt_dt_lend.Text = this.date_lend.Text;
            obj.txt_dt_pick.Text = this.date_pick.Text;
            obj.txt_lplate.Text = this.cmb_vid.Text;
            obj.txt_make.Text = this.txt_make.Text;
            obj.txt_model.Text = this.txt_model.Text;
            obj.Show();
        }

        private void cmb_cusid_DropDownClosed(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = db.getData("select * from Customer where Cus_ID='" + cmb_cusid.Text + "'");
            txt_cusFname.Text = dt.Rows[0][1].ToString();
            txt_cusLname.Text = dt.Rows[0][2].ToString();
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
            dt = db.getData("select * from Driver where D_ID='" + cmb_did.Text + "'");
            txt_dname.Text = dt.Rows[0][2].ToString();
        }
    }
}
