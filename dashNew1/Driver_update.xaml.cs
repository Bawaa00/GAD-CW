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


namespace dashNew1
{
    /// <summary>
    /// Interaction logic for Driver.xaml
    /// </summary>
    public partial class Driver : Window
    {
        public Driver()
        {
            InitializeComponent();
        }

        Connect_DB obj = new Connect_DB();

        string filepath;

        private void btn_Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = System.IO.Path.GetFileName(filepath);
                string destinationPath = GetDestinationPath(name);
                string a = " update Driver set  L_num= '" + txt_Lnum.Text + "', D_name = '" + txt_Name.Text + "', " +
                                " Tel=  '" + txt_Tp.Text + "', Address= '" + txt_Address.Text + "',D_Path = '" + destinationPath + "' where D_ID  = '" + cbox_did.Text + "'";

                File.Copy(filepath, destinationPath, true);

                int line = obj.save_update_delete(a);
                if (line == 1)
                    MessageBox.Show("Data save Successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                else
                    MessageBox.Show("Data cannot save", "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (ArgumentNullException)
            {
                Messagebox msg = new Messagebox();
                msg.errorMsg("Please upload a photo");
                msg.Show();
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

        private String GetDestinationPath(string filename)
        {
            String appStartPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            string dir = appStartPath + "\\" + cbox_did.Text;
            // If directory does not exist, create it
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            appStartPath = String.Format(dir + "\\" + cbox_did.Text + ".jpg");
            return appStartPath;
        }

        private void btn_upload_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = false;
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            bool? result = open.ShowDialog();

            if (result == true)
            {
                filepath = open.FileName; // Stores Original Path in Textbox    
                ImageSource imgsource = new BitmapImage(new Uri(filepath)); // Just show The File In Image when we browse It
                img.Source = imgsource;
            }
        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            Messagebox msg = new Messagebox();
            string a = " Delete from Driver where D_ID = '" + cbox_did.Text + "'";

            int line = obj.save_update_delete(a);
            if (line == 1)
            {
                msg.informationMsg("Data deleted successfully");
                msg.Show();
            }
            else
            {
                msg.errorMsg("Sorry, couldn't delete your data.Please try again");
                msg.Show();
            }


            cbox_did.Items.Clear();
            txt_Lnum.Clear();
            txt_Name.Clear();
            txt_Tp.Clear();
            txt_Address.Clear();
            img.Source = null;
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            cbox_did.Items.Clear();
            txt_Lnum.Clear();
            txt_Name.Clear();
            txt_Tp.Clear();
            txt_Address.Clear();
            img.Source = null;
        }

        private void DRIVER_UPDATE_DELETE_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = obj.getData("select * from Driver");
            cbox_did.ItemsSource = dt.DefaultView;
            cbox_did.DisplayMemberPath = "D_ID";
            cbox_did.SelectedValuePath = "D_ID";
        }


        private void cbox_did_DropDownClosed(object sender, EventArgs e)
        {
            if (cbox_did.SelectedIndex == -1)
                error_msg.Text = "Please select a driver ID";
            else
            {
                error_msg.Text = "";
                DataTable dt = new DataTable();
                dt = obj.getData("select * from Driver where D_ID='" + cbox_did.Text + "'");
                txt_Lnum.Text = cbox_did.Text;
                txt_Lnum.Text = dt.Rows[0][1].ToString();
                txt_Name.Text = dt.Rows[0][2].ToString();
                txt_Tp.Text = dt.Rows[0][3].ToString();
                txt_Address.Text = dt.Rows[0][4].ToString();
                filepath = dt.Rows[0][5].ToString();
                ImageSource imgsource = new BitmapImage(new Uri(filepath));
                img.Source = imgsource;
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
    }
}
