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
                    Add_Insurnce obj = new Add_Insurnce();
                    this.Close();
                    obj.Show();
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
            obj.Show();

        }

        private void btn_cls_Click(object sender, RoutedEventArgs e)
        {
            txt_org.Clear();
            txt_tel.Clear();
            txt_address.Clear();
        }
    }
}
