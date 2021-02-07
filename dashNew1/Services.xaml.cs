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
    /// Interaction logic for Services.xaml
    /// </summary>
    public partial class Services : Window
    {
        Connect_DB db = new Connect_DB();

        public Services()
        {
            InitializeComponent();
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            
            string query = "Insert into Service values ('" + cmb_vid.Text + "','" + txt_Sid.Text + "','" + txt_Sdetails.Text + "','" + txt_milge.Text + "','" + txt_nxt.Text + "')";

            int i = db.save_update_delete(query);
            if (i == 1)
            {
                Messagebox msg = new Messagebox();
                msg.Show();
                add_service_form_Loaded(this, null);
            }
               
            else
            {
                Messagebox msg = new Messagebox();
                msg.errorMsg("Sorry, couldn't save your data.Please try again");
                msg.Show();
            }
        }

        private void add_service_form_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = db.getData("select * from Vehicle");
            cmb_vid.ItemsSource = dt.DefaultView;
            cmb_vid.DisplayMemberPath = "L_Plate";
            cmb_vid.SelectedValuePath = "L_Plate";

            
                dt = db.getData("Select max(S_ID) from Service");
                string id = dt.Rows[0][0].ToString();
            if (id == "")
            {
                txt_Sid.Text = "S001";
            }
            else
            {
                var prefix = Regex.Match(id, "^\\D+").Value;
                var number = Regex.Replace(id, "^\\D+", "");
                var i = int.Parse(number) + 1;
                var newString = prefix + i.ToString(new string('0', number.Length));
                txt_Sid.Text = newString;
            }
            

            txt_Sdetails.Clear();
            txt_nxt.Clear();
            txt_milge.Clear();
            cmb_vid.Text = "";
        }

        private void txt_milge_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_milge.Text.Length == 0)
            { error_msg.Text = "Please Enter Milage at sevice "; }
            else if (!Regex.IsMatch(txt_milge.Text, "^[0-9]*$"))
            { error_msg.Text = "Please enter numbers only"; }
            else
            {
                error_msg.Text = "";
                try
                {
                    txt_nxt.Text = (Int32.Parse(txt_milge.Text) + 2500).ToString();
                }
                catch (System.OverflowException)
                {
                    Messagebox msg = new Messagebox();
                    msg.errorMsg("Number too large");
                    msg.Show();
                    txt_milge.Clear();
                    txt_nxt.Clear();
                }
                catch (System.FormatException)
                {
                    Messagebox msg = new Messagebox();
                    msg.errorMsg("Please input a number");
                    msg.Show();
                    txt_milge.Clear();
                    txt_nxt.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            Update_Vehicle obj = new Update_Vehicle();
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

        private void btn_cls_Click(object sender, RoutedEventArgs e)
        {
            add_service_form_Loaded(this, null);
        }

        private void cmb_vid_DropDownClosed(object sender, EventArgs e)
        {
            if (cmb_vid.SelectedItem == null)
                error_msg.Text = "Please Select Vehicle ID";
            else
                error_msg.Text = "";
        }

        private void txt_Sdetails_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_Sdetails.Text.Length == 0)
                error_msg.Text = "Please Enter Service Details";
            else
                error_msg.Text = "";
        }

        private void txt_Sid_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (txt_Sdetails.Text.Length == 0)
                error_msg.Text = "Please Enter Service ID";
            else
                error_msg.Text = "";
        }
    }
}
