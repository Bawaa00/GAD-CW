﻿using System;
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
using Microsoft.Win32;
using System.Diagnostics;
using System.IO;

namespace dashNew1
{
    /// <summary>
    /// Interaction logic for Update_ownr.xaml
    /// </summary>
    public partial class Update_ownr : Window
    {
        public Update_ownr()
        {
            InitializeComponent();
        }
        Connect_DB db = new Connect_DB();
        string path;
        string newpath;

        private String GetDestinationPath(string filename)
        {
            String appStartPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            string dir = appStartPath + "\\" + cmb_oid.Text;
            // If directory does not exist, create it
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            appStartPath = String.Format(dir + "\\" + cmb_oid.Text + ".jpg");
            return appStartPath;
        }

        private void form_up_owner_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = db.getData("select * from Owner");
            cmb_oid.ItemsSource = dt.DefaultView;
            cmb_oid.DisplayMemberPath = "O_ID";
            cmb_oid.SelectedValuePath = "O_ID";
        }

        private void cmb_oid_DropDownClosed(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = db.getData("select * from Owner where O_ID = '"+cmb_oid.Text+"'");
            txt_nic.Text = dt.Rows[0][1].ToString();
            txt_name.Text = dt.Rows[0][2].ToString();
            txt_address.Text = dt.Rows[0][3].ToString();
            txt_contact.Text = dt.Rows[0][4].ToString();
            path = dt.Rows[0][5].ToString();
            ImageSource imgsource = new BitmapImage(new Uri(path));
            img_owner.Source = imgsource;
        }

        private void btn_upload_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = false;
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            bool? result = open.ShowDialog();

            if (result == true)
            {
                path = open.FileName; // Stores Original Path in Textbox    
                ImageSource imgsource = new BitmapImage(new Uri(path)); // Just show The File In Image when we browse It
                img_owner.Source = imgsource;
            }
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            string a = " update Owner set  O_ID= '" + cmb_oid.Text + "', O_NIC = '" + txt_nic.Text + "', " +
                           " O_Name=  '" + txt_name.Text + "', O_Address= '" + txt_address.Text + "',O_Tel = '"+txt_contact.Text+"' ,O_path = '" + path + "' where Driver_ID  = '" + cmb_oid.Text + "'";

            string name = System.IO.Path.GetFileName(path);
            string destinationPath = GetDestinationPath(name);

            File.Copy(path, destinationPath, true);
            //txt_did.Text = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);

            int line = db.save_update_delete(a);
            if (line == 1)
                MessageBox.Show("Data save Successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

            else
                MessageBox.Show("Data cannot save", "error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
