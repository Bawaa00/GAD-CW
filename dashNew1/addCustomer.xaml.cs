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
using Microsoft.Win32;
using System.IO;
using System.Diagnostics;
using System.Data;
using System.Text.RegularExpressions;

namespace dashNew1
{
    /// <summary>
    /// Interaction logic for addCustomer.xaml
    /// </summary>
    public partial class addCustomer : Window
    {
        public addCustomer()
        {
            InitializeComponent();
        }

        Connect_DB db = new Connect_DB();
        string filepath;

        private String GetDestinationPath(string filename)
        {
            String appStartPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            string dir = appStartPath + "\\" + txt_id.Text;
            // If directory does not exist, create it
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            appStartPath = String.Format(dir + "\\" + txt_id.Text + ".jpg");
            return appStartPath;
        }


        private void btn_submit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = System.IO.Path.GetFileName(filepath);
                string destinationPath = GetDestinationPath(name);
                File.Copy(filepath, destinationPath, true);

                string query = "Insert into Customer (Cus_ID,F_Name,S_name,Cus_address,Cus_Tel,L_Num,NIC,Cus_Path) values ('" + txt_id.Text + "','" + txt_fName.Text + "','" + txt_lName.Text + "','" + txt_address.Text + "','"+txt_contact.Text+"','" + txt_LicNum.Text + "','" + txt_NIC.Text + "','" + destinationPath + "')";


                int i = db.save_update_delete(query);
                if (i == 1)
                    { 
                      Messagebox msg = new Messagebox();
                      Add_Customer_Loaded(this, null);
                      msg.Show();
                    }
                else
                   {
                      Messagebox msg = new Messagebox();
                      msg.errorMsg("Sorry, couldn't save your data.Please try again");
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
                    filepath = open.FileName; // Stores Original Path in Textbox    
                    ImageSource imgsource = new BitmapImage(new Uri(filepath)); // Just show The File In Image when we browse It
                    img_cus.Source = imgsource;
                }
            }

            catch (Exception ex)
            {
                Messagebox msg = new Messagebox();
                msg.errorMsg("Oops soomething went worng. " + ex.Message);
                msg.Show();
            }
        }

        private void btn_cls_Click(object sender, RoutedEventArgs e)
        {
            Add_Customer_Loaded(this, null);
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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

        private void Add_Customer_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = db.getData("Select max(Cus_ID) from Customer");
            string id = dt.Rows[0][0].ToString();
            if (id == "")
            {
                txt_id.Text = "C001";
            }
            else
            {
                var prefix = Regex.Match(id, "^\\D+").Value;
                var number = Regex.Replace(id, "^\\D+", "");
                var i = int.Parse(number) + 1;
                var newString = prefix + i.ToString(new string('0', number.Length));
                txt_id.Text = newString;
            }
            txt_fName.Clear();
            txt_lName.Clear();
            txt_address.Clear();
            txt_NIC.Clear();
            txt_LicNum.Clear();
            txt_contact.Clear();
            img_cus.Source = null;
        }

        private void txt_fName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_fName.Text.Length == 0)
                error_msg.Text = "Please Enter First Name";
            else if (!Regex.IsMatch(txt_fName.Text, "^[a-zA-Z]+$"))
                error_msg.Text = "Invalid name";
            else
                error_msg.Text = "";
        }

        private void txt_lName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_lName.Text.Length == 0)
                error_msg.Text = "Please Enter Last Name";
            else if (!Regex.IsMatch(txt_lName.Text, "^[a-zA-Z]+$"))
                error_msg.Text = "Invalid name";
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

        private void txt_LicNum_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_LicNum.Text.Length == 0)
                error_msg.Text = "Please Enter License Number ";
            else
                error_msg.Text = "";
        }

        private void txt_NIC_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_NIC.Text.Length == 0)
                error_msg.Text = "Please Enter NIC ";
            else
                error_msg.Text = "";
        }

        private void txt_contact_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_contact.Text.Length == 0)
                error_msg.Text = "Please Enter Contact Number ";
            else if (!Regex.IsMatch(txt_contact.Text, @"^(?:7|0|(?:\+94))[0-9]{8,9}$"))

                error_msg.Text = "Telephone No not Valid";
            else
                error_msg.Text = "";
        }

        private void txt_id_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_id.Text.Length == 0)
                error_msg.Text = "Please Enter Customer ID ";
            else
                error_msg.Text = "";
        }
    }
}

