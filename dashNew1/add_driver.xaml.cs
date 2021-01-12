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
using System.IO;
using System.Diagnostics;
using System.Data;
using System.Text.RegularExpressions;


namespace dashNew1
{
    /// <summary>
    /// Interaction logic for add_driver.xaml
    /// </summary>
    public partial class add_driver : Window
    {
        public add_driver()
        {
            InitializeComponent();
        }
        Connect_DB db = new Connect_DB();
        string filepath;

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            string name = System.IO.Path.GetFileName(filepath);
            string destinationPath = GetDestinationPath(name);
            File.Copy(filepath, destinationPath, true);

            string a = "insert into  Driver values  ('" + txt_Did.Text + "','" + txt_Lnum.Text + "','" + txt_Name.Text + "','" + txt_Tp.Text + "','" + txt_Address.Text + "','" + filepath + "')";

          
           File.Copy(filepath, destinationPath, true);
            

            int line = db.save_update_delete(a);
            if (line == 1)
            {
                Messagebox msg = new Messagebox();
                add_driver1_Loaded(this, null);
                msg.Show();   
            }
            else
            {
                Messagebox msg = new Messagebox();
                msg.errorMsg("Unable to save data. Please try again");          
            }
        }

        private String GetDestinationPath(string filename)
        {
            String appStartPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            string dir = appStartPath + "\\" + txt_Did.Text;
            // If directory does not exist, create it
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            appStartPath = String.Format(dir + "\\" + txt_Did.Text + ".jpg");
            return appStartPath;
        }

        private void btn_Update_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = false;
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            bool? result = open.ShowDialog();

            if (result == true)
            {
                filepath = open.FileName; // Stores Original Path in Textbox    
                ImageSource imgsource = new BitmapImage(new Uri(filepath)); // Just show The File In Image when we browse It
                imd_addDriver.Source = imgsource;
            }
        }

        private void btn_cls_Click(object sender, RoutedEventArgs e)
        {
            add_driver1_Loaded(this,null);
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

        private void add_driver1_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = db.getData("Select max(D_ID) from Driver");
            string id = dt.Rows[0][0].ToString();
            var prefix = Regex.Match(id, "^\\D+").Value;
            var number = Regex.Replace(id, "^\\D+", "");
            var i = int.Parse(number) + 1;
            var newString = prefix + i.ToString(new string('0', number.Length));
            txt_Did.Text = newString;
            txt_Lnum.Clear();
            txt_Name.Clear();
            txt_Tp.Clear();
            txt_Address.Clear();
            imd_addDriver.Source = null;
        }
    }
}
