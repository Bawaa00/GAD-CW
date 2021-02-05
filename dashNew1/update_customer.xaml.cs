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
using System.Drawing;
using Microsoft.Win32;
using System.IO;
using MaterialDesignThemes.Wpf;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Text.RegularExpressions;

namespace dashNew1
{
    /// <summary>
    /// Interaction logic for update_customer.xaml
    /// </summary>
    public partial class update_customer : Window
    {
        public update_customer()
        {
            InitializeComponent();
        }

        Connect_DB db = new Connect_DB();
        string filepath;

        private void update_cutomer_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();

            dt = db.getData("select * from Customer ");
            CMB_UPDATE.ItemsSource = dt.DefaultView;
            CMB_UPDATE.DisplayMemberPath = "Cus_ID";
            CMB_UPDATE.SelectedValuePath = "Cus_ID";
        }

        private void CMB_UPDATE_DropDownClosed(object sender, EventArgs e)
        {if (CMB_UPDATE.SelectedItem == null)
            { error_msg.Text = "Pleasse Enter Customer ID"}
            else { error_msg.Text = "";


                DataTable dt = new DataTable();
                dt = db.getData("select * from Customer where Cus_ID='" + CMB_UPDATE.Text + "'");

                TXT_FIRSTNAME.Text = dt.Rows[0][1].ToString();
                TXT_LASTNAME.Text = dt.Rows[0][2].ToString();
                TXT_ADDRESS.Text = dt.Rows[0][3].ToString();
                TXT_LICENNUM.Text = dt.Rows[0][5].ToString();
                TXT_NIC.Text = dt.Rows[0][6].ToString();
                filepath = dt.Rows[0][7].ToString();
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = new Uri(filepath);
                image.EndInit();
                IMG_UPDATECUS.Source = image; }
        }

        private void BTN_UPDATE_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = System.IO.Path.GetFileName(filepath);
                string destinationPath = GetDestinationPath(name);
                File.Copy(filepath, destinationPath, true);

                string a = " update Customer set  F_name= '" + TXT_FIRSTNAME.Text + "', S_name = '" + TXT_LASTNAME.Text + "', " +
                                "Cus_address=  '" + TXT_ADDRESS.Text + "', L_Num= '" + TXT_LICENNUM.Text + "',NIC= '" + TXT_NIC.Text + "',Cus_Path = '" + filepath + "' where Cus_ID  = '" + CMB_UPDATE.Text + "'";



                File.Copy(filepath, destinationPath, true);


                int line = db.save_update_delete(a);
                if (line == 1)
                    MessageBox.Show("Data save Successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                else
                    MessageBox.Show("Data cannot save", "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private String GetDestinationPath(string filename)
        {

            String appStartPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            string dir = appStartPath + "\\" + CMB_UPDATE.Text;
            // If directory does not exist, create it
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            appStartPath = String.Format(dir + "\\" + CMB_UPDATE.Text + ".jpg");
            return appStartPath;
        }

        private void BTN_UPLOAD_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = false;
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            bool? result = open.ShowDialog();

            if (result == true)
            {
                filepath = open.FileName;   
                ImageSource imgsource = new BitmapImage(new Uri(filepath));
                IMG_UPDATECUS.Source = imgsource;
            }


        }

        private void BTN_DELETE_Click(object sender, RoutedEventArgs e)
        {
            string a = " Delete from Customer where Cus_ID = '" + CMB_UPDATE.Text + "'";

            int line = db.save_update_delete(a);
            if (line == 1)
                MessageBox.Show("Data delete Successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

            else
                MessageBox.Show("Data cannot delete", "error", MessageBoxButton.OK, MessageBoxImage.Error);


            CMB_UPDATE.Items.Clear();
            TXT_FIRSTNAME.Clear();
            TXT_LASTNAME.Clear();
            TXT_ADDRESS.Clear();
            TXT_LICENNUM.Clear();
            TXT_NIC.Clear();
            IMG_UPDATECUS.Source = null;
        }

        private void BTN_CLEAR_Click(object sender, RoutedEventArgs e)
        {
            CMB_UPDATE.ItemsSource = null;
            CMB_UPDATE.Items.Clear();
            TXT_FIRSTNAME.Clear();
            TXT_LASTNAME.Clear();
            TXT_ADDRESS.Clear();
            TXT_LICENNUM.Clear();
            TXT_NIC.Clear();
            IMG_UPDATECUS.Source = null;
        }

        private void BTN_HOME_Click(object sender, RoutedEventArgs e)
        {
            MainWindow obj = new MainWindow();
            this.Close();
            obj.Show();
        }

        private void BTN_BACK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TXT_FIRSTNAME_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TXT_FIRSTNAME.Text.Length == 0)
                error_msg.Text = "Please Enter First name Name";
            else if (!Regex.IsMatch(TXT_FIRSTNAME.Text, "^[a-zA-Z]+$"))
                error_msg.Text = "Invalid name";
            else
                error_msg.Text = "";
        }

        private void TXT_LASTNAME_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TXT_LASTNAME.Text.Length == 0)
                error_msg.Text = "Please Enter Last Name ";
            else if (!Regex.IsMatch(TXT_LASTNAME.Text, "^[a-zA-Z]+$"))
                error_msg.Text = "Invalid name";
            else
                error_msg.Text = "";
        }

        private void TXT_ADDRESS_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TXT_ADDRESS.Text.Length == 0)
                error_msg.Text = "Please Enter Address";
            else
                error_msg.Text = "";
        }

        private void TXT_LICENNUM_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (TXT_LICENNUM.Text.Length == 0)
                error_msg.Text = "Please Enter License Number";
            else
                error_msg.Text = "";
        }

        private void TXT_NIC_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TXT_NIC.Text.Length == 0)
                error_msg.Text = "Please Enter NIC Number";
            else
                error_msg.Text = "";
        }
    }
}
