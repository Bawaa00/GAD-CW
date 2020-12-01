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
            string name = System.IO.Path.GetFileName(filepath);
            string destinationPath = GetDestinationPath(name);
            File.Copy(filepath, destinationPath, true);

            string query = "Insert into Owner values ('" + txt_oid.Text + "','" + txt_onic.Text + "','" + txt_oname.Text + "','" + txt_address.Text + "','" + txt_contact.Text + "','" + destinationPath + "')";

            int i = db.save_update_delete(query);
            if (i == 1)
                MessageBox.Show("Data save Successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("Data cannot save", "error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void btn_cls_Click(object sender, RoutedEventArgs e)
        {
            txt_oid.Clear();
            txt_onic.Clear();
            txt_oname.Clear();
            txt_address.Clear();
            txt_contact.Clear();
            img_owner.Source = null;
        }
    }
}
