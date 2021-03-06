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
using System.Text.RegularExpressions;

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

            if (cmb_oid.SelectedIndex == 0)
            { error_msg.Text = "Please Select Owner ID"; }
            else
            {

                error_msg.Text = "";

                DataTable dt = new DataTable();
                dt = db.getData("select * from Owner where O_ID = '" + cmb_oid.Text + "'");
                txt_nic.Text = dt.Rows[0][1].ToString();
                txt_name.Text = dt.Rows[0][2].ToString();
                txt_address.Text = dt.Rows[0][3].ToString();
                txt_contact.Text = dt.Rows[0][4].ToString();
                path = dt.Rows[0][5].ToString();

                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = new Uri(path);
                image.EndInit();
                img_owner.Source = image;
            }
        }

        private void btn_upload_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Multiselect = false;
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                bool? result = open.ShowDialog();

                if (result == true)
                {
                    path = open.FileName; // Stores Original Path in Textbox    
                    /* ImageSource imgsource = new BitmapImage(new Uri(path)); // Just show The File In Image when we browse It
                     img_owner.Source = imgsource;*/
                    BitmapImage image = new BitmapImage();
                    image.BeginInit();
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.UriSource = new Uri(path);
                    image.EndInit();
                    img_owner.Source = image;
                }
            }
            catch (Exception ex)
            {
                Messagebox msg = new Messagebox();
                msg.errorMsg("Oops soomething went worng. " + ex.Message);
                msg.Show();
            }
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Messagebox msg = new Messagebox();
                string a = "update Owner set O_ID='" + cmb_oid.Text + "' , O_NIC = '" + txt_nic.Text + "' , O_path = '" + path + "' , O_Tel = " + txt_contact.Text + " ,O_Name = '" + txt_name.Text + "', O_Address = '" + txt_address.Text + "' where O_ID = '" + cmb_oid.Text + "' ";
                string name = System.IO.Path.GetFileName(path);
                string destinationPath = GetDestinationPath(name);

                File.Copy(path, destinationPath, true);
                // txt_did.Text = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);

                int line = db.save_update_delete(a);
                if (line == 1)
                {
                    msg.informationMsg("Data Updated Successfully!");
                    msg.Show();
                }
                else
                {
                    msg.errorMsg("Unable to Update Data.Please check again");
                    msg.Show();
                }
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

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_clr_Click(object sender, RoutedEventArgs e)
        {
            txt_nic.Clear();
            txt_name.Clear();
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

        private void btn_back1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void txt_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_name.Text.Length == 0)
                error_msg.Text = "Please Enter Owner Name";
            else if (!Regex.IsMatch(txt_name.Text, "^[a-zA-Z]+$"))
                error_msg.Text = "Invalid name";
            else
                error_msg.Text = "";
        }

        private void cmb_oid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txt_nic_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_nic.Text.Length == 0)
                error_msg.Text = "  Please Enter Owner NIC ";
            else
                error_msg.Text = "";
        }

        private void txt_address_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_address.Text.Length == 0)
                error_msg.Text = "  Please Enter Owner Address ";
            else
                error_msg.Text = "";
        }

        private void txt_contact_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_contact.Text.Length == 0)
                error_msg.Text = "Please Enter Contact Number ";
            else if (!Regex.IsMatch(txt_contact.Text, @"^(?:7|0|(?:\+94))[0-9]{8,9}$"))

                error_msg.Text = "Contact Number not Valid";
            else
                error_msg.Text = "";
        }
    }
}
