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
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;
using System.Text.RegularExpressions;

namespace dashNew1
{
    /// <summary>
    /// Interaction logic for Updt_vehicle.xaml
    /// </summary>
    public partial class Updt_vehicle : Window
    {
        public Updt_vehicle()
        {
            InitializeComponent();
        }
        Connect_DB db = new Connect_DB();
        string path;
        string old_id;

        private String GetDestinationPath(string filename)
        {
            String appStartPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            string dir = appStartPath + "\\" + cbox_lplate.Text;
            // If directory does not exist, create it
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            appStartPath = String.Format(dir + "\\" + cbox_lplate.Text + ".jpg");
            return appStartPath;
        }

        private void form_vehicle_update_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = db.getData("select * from Vehicle");
            cbox_lplate.ItemsSource = dt.DefaultView;
            cbox_lplate.DisplayMemberPath = "L_Plate";
            cbox_lplate.SelectedValuePath = "L_Plate";

            cbox_oid.ItemsSource = dt.DefaultView;
            cbox_oid.DisplayMemberPath = "O_ID";
            cbox_oid.SelectedValuePath = "O_ID";

            dt = db.getData("select * from Insurance");
            cbox_ins.ItemsSource = dt.DefaultView;
            cbox_ins.DisplayMemberPath = "I_ID";
            cbox_ins.SelectedValuePath = "I_ID";
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
                    BitmapImage image = new BitmapImage();
                    image.BeginInit();
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.UriSource = new Uri(path);
                    image.EndInit();
                    img_vehicle.Source = image;

                }
            }
            catch (Exception ex)
            {
                Messagebox msg = new Messagebox();
                msg.errorMsg("Oops soomething went worng. " + ex.Message);
                msg.Show();
            }
        }

        private void cbox_lplate_DropDownClosed(object sender, EventArgs e)
        {
            if (cbox_lplate.SelectedItem == null) { error_msg.Text = "Please Select License Number"; }
            else { error_msg.Text = "";
                if (cbox_lplate.Text != "")
                {
                    DataTable dt = new DataTable();
                    dt = db.getData("select * from Vehicle where L_Plate='" + cbox_lplate.Text.ToString() + "'");
                    old_id = dt.Rows[0][0].ToString();
                    cbox_year.Text = dt.Rows[0][1].ToString();
                    cbox_make.Text = dt.Rows[0][2].ToString();
                    txt_model.Text = dt.Rows[0][3].ToString();
                    cbox_category.Text = dt.Rows[0][4].ToString();
                    txt_cpweek.Text = dt.Rows[0][6].ToString();
                    txt_cpmonth.Text = dt.Rows[0][5].ToString();
                    txt_extra.Text = dt.Rows[0][7].ToString();
                    cbox_oid.Text = dt.Rows[0][8].ToString();
                    txt_lndate.Text = dt.Rows[0][9].ToString();
                    cbox_ins.Text = dt.Rows[0][10].ToString();
                    txt_sdate.Text = dt.Rows[0][11].ToString();
                    txt_exdate.Text = dt.Rows[0][12].ToString();
                    path = dt.Rows[0][13].ToString();
                    BitmapImage image = new BitmapImage();
                    image.BeginInit();
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.UriSource = new Uri(path);
                    image.EndInit();
                    img_vehicle.Source = image;
                }
            }

        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Messagebox msg = new Messagebox();
                string name = System.IO.Path.GetFileName(path);
                string destinationPath = GetDestinationPath(name);
                File.Copy(path, destinationPath, true);

                string q = "update Vehicle set L_Plate='" + cbox_lplate.Text + "',Year='" + cbox_year.Text + "',Make='" + cbox_make.Text + "',Model='" + txt_model.Text + "',Category='" + cbox_category.Text + "'" +
                    ",Cost_Per_Month='" + txt_cpmonth.Text + "',Cost_Per_Week='" + txt_cpweek.Text + "',Extra_Cost='" + txt_extra.Text + "',O_ID='" + cbox_oid.Text + "',Lend_Date='" + txt_lndate.Text + "'," +
                    "S_date='" + txt_sdate.Text + "',E_date='" + txt_exdate.Text + "', V_Path = '" + destinationPath + "'  where L_Plate = '" + old_id + "'";

                int i = db.save_update_delete(q);
                if (i == 1)
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

        private void btn_up_owner_Click(object sender, RoutedEventArgs e)
        {
            Owner_info obj = new Owner_info();
            obj.Show();
        }

        private void btn_up_ins_Click(object sender, RoutedEventArgs e)
        {
            View_insurnce obj = new View_insurnce();
            obj.Show();
        }

        private void btn_del_Click(object sender, RoutedEventArgs e)
        {
            int i = db.save_update_delete("delete from Vehicle where L_Plate='" + cbox_lplate.Text + "'");
            if (i == 1)
                MessageBox.Show("Data Deleted Successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

            else
                MessageBox.Show("Data Cannot Delete", "error", MessageBoxButton.OK, MessageBoxImage.Error);
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

        private void cbox_year_DropDownClosed(object sender, EventArgs e)
        {
            if (cbox_year.SelectedItem == null)
            { error_msg.Text = "Please Select Year"; }
            else { error_msg.Text = ""; }
        }

        private void cbox_make_DropDownClosed(object sender, EventArgs e)
        {

            if (cbox_make.SelectedItem == null)
            { error_msg.Text = "Please Select Make"; }
            else { error_msg.Text = ""; }
        }

        private void cbox_category_DropDownClosed(object sender, EventArgs e)
        {

            if (cbox_category.SelectedItem == null)
            { error_msg.Text = "Please Select Category"; }
            else { error_msg.Text = ""; }
        }

        private void txt_model_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_model.Text.Length == 0)
                error_msg.Text = "Please Enter Model";
            else
                error_msg.Text = "";
        }

        private void txt_cpweek_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (txt_cpweek.Text.Length == 0)
                error_msg.Text = "Please Enter Cost per week ";
            else if (!Regex.IsMatch(txt_cpweek.Text, "^[0-9]*$"))
                error_msg.Text = "Please enter numbers only";
            else
                error_msg.Text = "";

        }

        private void txt_cpmonth_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (txt_cpmonth.Text.Length == 0)
                error_msg.Text = "Please Enter Cost per Month ";
            else if (!Regex.IsMatch(txt_cpmonth.Text, "^[0-9]*$"))
                error_msg.Text = "Please enter numbers only";
            else
                error_msg.Text = "";
        }

        private void txt_extra_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (txt_extra.Text.Length == 0)
                error_msg.Text = "Please Enter Extra Cost per Milage ";
            else if (!Regex.IsMatch(txt_extra.Text, "^[0-9]*$"))
                error_msg.Text = "Please enter numbers only";
            else
                error_msg.Text = "";



        }

        private void cbox_oid_DropDownClosed(object sender, EventArgs e)
        {
            if (cbox_oid.SelectedItem == null)
            { error_msg.Text = "Please Select Owner ID"; }
            else { error_msg.Text = ""; }
        }

        private void cbox_ins_DropDownClosed(object sender, EventArgs e)
        {
            if (cbox_ins.SelectedItem == null)
            { error_msg.Text = "Please Select Insurance"; }
            else { error_msg.Text = ""; }

        }
    }
}
