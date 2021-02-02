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
using System.Text.RegularExpressions;
using System.Data;
using Microsoft.Win32;

namespace dashNew1
{
    /// <summary>
    /// Interaction logic for Add_Insurnce.xaml
    /// </summary>
    public partial class Add_Insurnce : Window
    {
        public Add_Insurnce()
        {
            InitializeComponent();
        }
        Connect_DB db = new Connect_DB();

        private void Add_Insurance_Form_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = db.getData("Select max(I_ID) from Insurance ");

            string id = dt.Rows[0][0].ToString();
            var prefix = Regex.Match(id, "^\\D+").Value;
            var number = Regex.Replace(id, "^\\D+", "");
            var i = int.Parse(number) + 1;
            var newString = prefix + i.ToString(new string('0', number.Length));
            txt_iid.Text = newString;
            txt_org.Clear();
            txt_tel.Clear();
            txt_address.Clear();

        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                string query = "Insert into Insurance values ('" + txt_iid.Text + "','" + txt_org.Text + "','" + txt_address.Text + "','" + txt_tel.Text + "')";
                int i = db.save_update_delete(query);
                if (i == 1)
                {
                    Messagebox msg = new Messagebox();
                    Add_Insurance_Form_Loaded(this, null);
                    msg.Show();
                }
                else
                {
                    Messagebox msg = new Messagebox();
                    msg.errorMsg("Sorry, couldn't save your data.Please try again");
                    msg.Show();
                }
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); 
            }
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_home_Click(object sender, RoutedEventArgs e)
        {
            MainWindow obj = new MainWindow();
            this.Close();
            obj.Show();
        }

        private void btn_cls_Click(object sender, RoutedEventArgs e)
        {
            Add_Insurance_Form_Loaded(this, null);
        }

        private void txt_org_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_org.Text.Length == 0)
                error_msg.Text = "Please Enter Company Name";
            else
                error_msg.Text = "";
        }

        private void txt_tel_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_tel.Text.Length == 0)
                error_msg.Text = "Please Enter Telephone NUmber ";
            else if (!Regex.IsMatch(txt_tel.Text, @"^(?:7|0|(?:\+94))[0-9]{8,9}$"))
                error_msg.Text = "Telephone No not Valid";
            else
                error_msg.Text = "";
        }

        private void txt_address_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_address.Text.Length == 0)
                error_msg.Text = "Please Enter Address ";
            else
                error_msg.Text = "";
        }

        private void txt_iid_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_iid.Text.Length == 0)
                error_msg.Text = "Please Enter Insurance ID";
            else
                error_msg.Text = "";

        }
    }
}
