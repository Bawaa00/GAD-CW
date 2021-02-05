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
using Microsoft.Win32;

namespace dashNew1
{
    /// <summary>
    /// Interaction logic for add_repairs.xaml
    /// </summary>
    public partial class add_repairs : Window
    {
        public add_repairs()
        {
            InitializeComponent();
        }

        Connect_DB db = new Connect_DB();

        private void cmb_type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmb_type.SelectedIndex == 0)
            {
                lbl_claim.Visibility = Visibility.Hidden;
                txt_claim.Visibility = Visibility.Hidden;
                DataTable dt = new DataTable();
                dt = db.getData("Select max(r_ID) from Maintenance ");

                string id = dt.Rows[0][0].ToString();
                var prefix = Regex.Match(id, "^\\D+").Value;
                var number = Regex.Replace(id, "^\\D+", "");
                var i = int.Parse(number) + 1;
                var newString = prefix + i.ToString(new string('0', number.Length));
                txt_rid.Text = newString;
            }
            else if (cmb_type.SelectedIndex == 1 )
            {
                lbl_claim.Visibility = Visibility.Visible;
                txt_claim.Visibility = Visibility.Visible;

                lbl_claim.Visibility = Visibility.Hidden;
                txt_claim.Visibility = Visibility.Hidden;
                DataTable dt = new DataTable();
                dt = db.getData("Select max(R_ID) from Acc_repair ");

                string id = dt.Rows[0][0].ToString();
                var prefix = Regex.Match(id, "^\\D+").Value;
                var number = Regex.Replace(id, "^\\D+", "");
                var i = int.Parse(number) + 1;
                var newString = prefix + i.ToString(new string('0', number.Length));
                txt_rid.Text = newString;

            }
        }

        private void add_repair_form_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = db.getData("select * from Vehicle");
            cmb_vid.ItemsSource = dt.DefaultView;
            cmb_vid.DisplayMemberPath = "L_Plate";
            cmb_vid.SelectedValuePath = "L_Plate";
            txt_details.Clear();
            txt_date.Text = "";
            txt_cost.Clear();
            txt_claim.Clear();
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cmb_type.SelectedIndex == 0)
                {
                    string query = "Insert into Maintenance values ('" + txt_rid.Text + "','" + cmb_vid.Text + "','" + txt_details.Text + "','" + txt_date.Text + "','" + txt_cost.Text + "');";
                    int i = db.save_update_delete(query);
                if (i == 1 || i == -1)
                    { 
                      Messagebox msg = new Messagebox();
                        add_repair_form_Loaded(this, null);
                        msg.Show();
                    }
                else
                   {
                      Messagebox msg = new Messagebox();
                      msg.errorMsg("Sorry, couldn't save your data.Please try again");
                      msg.Show();
                   }
                }
                else if (cmb_type.SelectedIndex == 1)
                {
                    string query = "Insert into Acc_repair values ('" + txt_rid.Text + "','" + cmb_vid.Text + "','" + txt_details.Text + "','" + txt_date.Text + "','" + txt_cost.Text + "','" + txt_claim.Text + "');";
                    int i = db.save_update_delete(query);
                    if (i == 1 || i == -1)
                    { 
                      Messagebox msg = new Messagebox();
                      add_repair_form_Loaded(this, null);
                      msg.Show();
                    }
                else
                   {
                      Messagebox msg = new Messagebox();
                      msg.errorMsg("Sorry, couldn't save your data.Please try again");
                      msg.Show();
                   }
                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                Messagebox msg = new Messagebox();
                msg.errorMsg("Please fill the form correctly. Database Error");
                msg.Show();
            }


            catch (Exception ex)
            {
                Messagebox msg = new Messagebox();
                msg.errorMsg("Oops something went worng. " + ex.Message);
                msg.Show();
            }
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
            add_repair_form_Loaded(this,null);
        }

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            Update_Vehicle obj = new Update_Vehicle();
            obj.Show();
        }

        private void txt_details_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_details.Text.Length == 0)
                error_msg.Text = "Please Enter Driver ID ";
            else
                error_msg.Text = "";
        }

        private void cmb_vid_DropDownClosed(object sender, EventArgs e)
        {
            if (cmb_vid.SelectedItem==null)
                error_msg.Text = "Please Select Vechicle ID  ";
            else
                error_msg.Text = "";
        }

        private void txt_cost_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_cost.Text.Length == 0)
                error_msg.Text = "Please Enter Repair cost ";
            else
                error_msg.Text = "";
        }

        private void txt_claim_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_claim.Text.Length == 0)
                error_msg.Text = "Please Enter  Claim Amount  ";
            else
                error_msg.Text = "";
        }
    }
}
