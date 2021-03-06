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
using System.Drawing;
using Microsoft.Win32;
using System.IO;
using MaterialDesignThemes.Wpf;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
namespace dashNew1
{
    /// <summary>
    /// Interaction logic for update_repair.xaml
    /// </summary>
    public partial class update_repair : Window
    {
        public update_repair()
        {
            InitializeComponent();
        }
        Connect_DB db = new Connect_DB();

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (cmb_type.SelectedIndex == 0)
                {
                    string a = " update Acc_repair set  VNO= '" + TXT_VID.Text + "', R_details = '" + txt_details.Text + "', " +
                                  " R_date=  '" + txt_date.Text + "', cost= '" + txt_cost.Text + "',Claim_amt= '" + txt_claim + "' where R_ID = '" + cmb_RID.Text + "'";


                    int line = db.save_update_delete(a);
                    if (line == 1)
                        MessageBox.Show("Data save Successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                    else
                        MessageBox.Show("Data cannot save", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (cmb_type.SelectedIndex == 1)
                {
                    string a = " update Acc_repair set  VNO= '" + TXT_VID.Text + "', R_details = '" + txt_details.Text + "', " +
                                      " R_date=  '" + txt_date.Text + "', cost= '" + txt_cost.Text + "',Claim_amt= '" + txt_claim + "' where R_ID = '" + cmb_RID.Text + "'";


                    int line = db.save_update_delete(a);
                    if (line == 1)
                        MessageBox.Show("Data save Successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                    else
                        MessageBox.Show("Data cannot save", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
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
                string dir = appStartPath + "\\" + cmb_RID.Text;
                // If directory does not exist, create it
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                appStartPath = String.Format(dir + "\\" + cmb_RID.Text + ".jpg");
                return appStartPath;
            }

        

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            if(cmb_type.SelectedIndex == 0)
            {
                string a = " Delete from Maintenance where R_id = '" + cmb_RID.Text + "'";
                int line = db.save_update_delete(a);
                if (line == 1)
                {
                    Messagebox msg = new Messagebox();
                    msg.Show();
                    cmb_RID.ItemsSource = null;
                    cmb_RID.Items.Clear();
                    cmb_type.SelectedIndex = -1;
                    TXT_VID.Clear();
                    txt_details.Clear();
                    txt_date.Text = null;
                    txt_cost.Clear();
                }
                else
                {
                    Messagebox msg = new Messagebox();
                    msg.errorMsg("Sorry, couldn't save your data.Please try again");
                    msg.Show();
                }
            }
            else if (cmb_type.SelectedIndex ==1)
            {
                string a = " Delete from Acc_repair where R_ID = '" + cmb_RID.Text + "'";
                int line = db.save_update_delete(a);
                if (line == 1)
                {
                    Messagebox msg = new Messagebox();
                    msg.Show();
                    cmb_RID.ItemsSource = null;
                    cmb_RID.Items.Clear();
                    cmb_type.SelectedIndex = -1;
                    TXT_VID.Clear();
                    txt_details.Clear();
                    txt_date.Text = null;
                    txt_cost.Clear();
                    txt_claim.Clear();
                }
                else
                {
                    Messagebox msg = new Messagebox();
                    msg.errorMsg("Sorry, couldn't save your data.Please try again");
                    msg.Show();
                }
                    
            }       
        }


        private void cmb_RID_DropDownClosed(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                if (cmb_type.SelectedIndex == 0)
                {
                    dt = db.getData("select * from Maintenance where R_id='" + cmb_RID.Text + "'");
                    TXT_VID.Text = dt.Rows[0][1].ToString();
                    txt_details.Text = dt.Rows[0][2].ToString();
                    txt_date.Text = dt.Rows[0][3].ToString();
                    txt_cost.Text = dt.Rows[0][4].ToString();
                    txt_error.Text = "";
                }
                else if (cmb_type.SelectedIndex == 1)
                {
                    dt = db.getData("select * from Acc_repair where R_ID='" + cmb_RID.Text + "'");
                    TXT_VID.Text = dt.Rows[0][1].ToString();
                    txt_details.Text = dt.Rows[0][2].ToString();
                    txt_date.Text = dt.Rows[0][3].ToString();
                    txt_cost.Text = dt.Rows[0][4].ToString();
                    txt_claim.Text = dt.Rows[0][5].ToString();
                    txt_error.Text = "";
                }
                else
                {
                    txt_error.Text = "Please select a Repair ID";
                }
            }
            catch (IndexOutOfRangeException)
            {
                Messagebox obj = new Messagebox();
                obj.errorMsg("Database Error");
                obj.Show();
            }
            catch (Exception ex)
            {
                Messagebox msg = new Messagebox();
                msg.errorMsg("Oops soomething went worng. " + ex.Message);
                msg.Show();
            }
        }

        private void btn_clear_Click(object sender, RoutedEventArgs e)
        {
            cmb_RID.ItemsSource = null;
            cmb_RID.Items.Clear();
            cmb_type.SelectedIndex = -1;
            TXT_VID.Clear();
            txt_details.Clear();
            txt_date.Text = null;
            txt_cost.Clear();
            txt_claim.Clear();
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

        private void cmb_type_DropDownClosed(object sender, EventArgs e)
        {
            


                DataTable dt = new DataTable();
                if (cmb_type.SelectedIndex == 0)
                {
                    dt = db.getData("select * from Maintenance");
                    cmb_RID.ItemsSource = dt.DefaultView;
                    cmb_RID.DisplayMemberPath = "R_id";
                    cmb_RID.SelectedValuePath = "R_id";
                    txt_claim.Visibility = Visibility.Hidden;
                    lbl_claim.Visibility = Visibility.Hidden;
                    txt_error.Text = "";
                }
                else if (cmb_type.SelectedIndex == 1)
                {
                    dt = db.getData("select * from Acc_repair");
                    cmb_RID.ItemsSource = dt.DefaultView;
                    cmb_RID.DisplayMemberPath = "R_ID";
                    cmb_RID.SelectedValuePath = "R_ID";
                    txt_claim.Visibility = Visibility.Visible;
                    lbl_claim.Visibility = Visibility.Visible;
                    txt_error.Text = "";
                }
                else
                {
                    txt_error.Text = "Please select a Repair Type";
                }
            
        }

        private void txt_details_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_details.Text.Length == 0)
                txt_error.Text = " Please Enter Repair Detail";
            else
                txt_error.Text = "";
        }

        private void txt_cost_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_cost.Text.Length == 0)
                txt_error.Text = "Please Enter Repair Cost ";
            else if (!Regex.IsMatch(txt_cost.Text, "^[0-9]*$"))
                txt_error.Text = "Please enter numbers only";
            else
                txt_error.Text = "";

        }

        private void txt_claim_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_claim.Text.Length == 0)
                txt_error.Text = "Please Enter Repair Claimed Amount  ";
            else if (!Regex.IsMatch(txt_claim.Text, "^[0-9]*$"))
                txt_error.Text = "Please enter numbers only";
            else
                txt_error.Text = "";
        }

        private void TXT_VID_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TXT_VID.Text.Length == 0)
                txt_error.Text = " Please Enter Vehicle ID";
            else
                txt_error.Text = "";
        }
    }
}
