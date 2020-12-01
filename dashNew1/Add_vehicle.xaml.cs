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
using System.Diagnostics;
using System.IO;
using System.Data;
using Microsoft.Win32;

namespace dashNew1
{
    /// <summary>
    /// Interaction logic for Add_vehicle.xaml
    /// </summary>
    public partial class Add_vehicle : Window
    {
        public Add_vehicle()
        {
            InitializeComponent();
        }

        Connect_DB db = new Connect_DB();
        string filepath;

        private String GetDestinationPath(string filename)
        {
            String appStartPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            string dir = appStartPath + "\\" + txt_lno.Text;
            // If directory does not exist, create it
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            appStartPath = String.Format(dir + "\\" + txt_lno.Text + ".jpg");
            return appStartPath;
        }

        private void btn_edit_owner_Click(object sender, RoutedEventArgs e)
        {
            Add_owner obj = new Add_owner();
            obj.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Add_Insurnce obj = new Add_Insurnce();
            obj.Show();
        }

        private void Vehicle_Setup_Form_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = db.getData("select * from Owner");
            cbox_oid.ItemsSource = dt.DefaultView;
            cbox_oid.DisplayMemberPath = "O_ID";
            cbox_oid.SelectedValuePath = "O_ID";
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
                img_vehicle.Source = imgsource;
            }
        }
    }
}
