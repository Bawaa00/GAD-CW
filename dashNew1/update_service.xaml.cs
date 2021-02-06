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
    /// Interaction logic for update_service.xaml
    /// </summary>
    public partial class update_service : Window
    {
        public update_service()
        {
            InitializeComponent();
        }
        Connect_DB db = new Connect_DB();

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string a = " update Service set  VNo= '" + txt_vehiclenum.Text + "', s_details = '" + txt_Sdetails.Text + "', " +
                                                      " S_milage=  '" + txt_milge.Text + "', Nxt_milage= '" + txt_nxt.Text + "' where S_ID  = '" + cmb_updateser.Text + "'";



                int line = db.save_update_delete(a);
                if (line == 1)
                    MessageBox.Show("Data save Successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                else
                    MessageBox.Show("Data cannot save", "error", MessageBoxButton.OK, MessageBoxImage.Error);
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

        private void UPDATE_SERVICE_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = db.getData("select * from Service");
            cmb_updateser.ItemsSource = dt.DefaultView;
            cmb_updateser.DisplayMemberPath = "S_ID";
            cmb_updateser.SelectedValuePath = "S_ID";
        }

        private void BTN_CLEAR_Click(object sender, RoutedEventArgs e)
        {
            cmb_updateser.ItemsSource = null;
            cmb_updateser.Items.Clear();
            txt_vehiclenum.Clear();
            txt_milge.Clear();
            txt_nxt.Clear();
            txt_Sdetails.Clear();
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            string a = " Delete from Service where S_ID = '" + cmb_updateser.Text + "'";

            int line = db.save_update_delete(a);
            if (line == 1)
                MessageBox.Show("Data delete Successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

            else
                MessageBox.Show("Data cannot delete", "error", MessageBoxButton.OK, MessageBoxImage.Error);

            cmb_updateser.ItemsSource = null;
            cmb_updateser.Items.Clear();
            txt_vehiclenum.Clear();
            txt_milge.Clear();
            txt_nxt.Clear();
            txt_Sdetails.Clear();

        }

        private void BTN_HOME_Click(object sender, RoutedEventArgs e)
        {
            MainWindow obj = new MainWindow();
            this.Close();
            obj.Show();
        }

        private void cmb_updateser_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                if (cmb_updateser.SelectedIndex == 0)
                { error_msg.Text = "Please Select Service ID"; }
                else
                {
                    error_msg.Text = "";
                    DataTable dt = new DataTable();
                    dt = db.getData("select * from Service where S_ID='" + cmb_updateser.Text + "'");

                    txt_vehiclenum.Text = dt.Rows[0][0].ToString();
                    txt_Sdetails.Text = dt.Rows[0][2].ToString();
                    txt_milge.Text = dt.Rows[0][3].ToString();
                    txt_nxt.Text = dt.Rows[0][4].ToString();
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

        private void BTN_BACK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void txt_vehiclenum_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_vehiclenum.Text.Length == 0)
                error_msg.Text = " Please Enter Vehicle ID";
            else
                error_msg.Text = "";
        }

        private void txt_Sdetails_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_Sdetails.Text.Length == 0)
                error_msg.Text = " Please Enter Service Details";
            else
                error_msg.Text = "";
        }

        private void txt_milge_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_milge.Text.Length == 0)
                error_msg.Text = " Please Enter Meliage at Sevrice";
            else
                error_msg.Text = "";
        }

        private void txt_nxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_nxt.Text.Length == 0)
                error_msg.Text = " Please Enter Next Service";
            else
                error_msg.Text = "";
        }
    }
}
