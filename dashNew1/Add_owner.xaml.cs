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
using Microsoft.Win32;
using System.Diagnostics;
using System.IO;
using System.Data;
using System.Text.RegularExpressions;

namespace dashNew1
{
    /// <summary>
    /// Interaction logic for Add_owner.xaml
    /// </summary>
    public partial class Add_owner : Window
    {
        public Add_owner()
        {
            InitializeComponent();
        }
        string filepath;
        Connect_DB db = new Connect_DB();

        private String GetDestinationPath(string filename)
        {
            String appStartPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            string dir = appStartPath + "\\" + txt_oid.Text;
            // If directory does not exist, create it
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            appStartPath = String.Format(dir + "\\" + txt_oid.Text + ".jpg");
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
                img_owner.Source = imgsource;
            }
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               
                string name = System.IO.Path.GetFileName(filepath);
                string destinationPath = GetDestinationPath(name);
                File.Copy(filepath, destinationPath, true);
                
                string query = "Insert into Owner values ('" + txt_oid.Text + "','" + txt_onic.Text + "','" + txt_oname.Text + "','" + txt_address.Text + "','" + txt_contact.Text + "','" + destinationPath + "')";

                int i = db.save_update_delete(query);
                if (i == 1)
                {   
                     Messagebox msg = new Messagebox();
                     msg.Show();
                     owner_form_Loaded(this, null);
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
            { 
                MessageBox.Show(ex.Message); 
            }

        }

        private void btn_cls_Click(object sender, RoutedEventArgs e)
        {
            owner_form_Loaded(this, null);
        }

        private void owner_form_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = db.getData("Select max(O_ID) from Owner ");
            string id = dt.Rows[0][0].ToString();
            var prefix = Regex.Match(id, "^\\D+").Value;
            var number = Regex.Replace(id, "^\\D+", "");
            var i = int.Parse(number) + 1;
            var newString = prefix + i.ToString(new string('0', number.Length));
            txt_oid.Text = newString;
            txt_onic.Clear();
            txt_oname.Clear();
            txt_address.Clear();
            txt_contact.Clear();
            img_owner.Source = null;
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
