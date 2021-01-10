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
    /// Interaction logic for view_driver.xaml
    /// </summary>
    public partial class view_driver : Window
    {
        public view_driver()
        {
            InitializeComponent();
        }
        Connect_DB db = new Connect_DB();

        private void view_driver1_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = db.getData("select D_ID as 'DRIVER ID', D_name as 'NAME',Driver.L_Num as'LICENS NUMBER',Driver.Tel as 'TELEPHONE',Driver.Address as 'ADDRESS'" +
                " from Driver;");
            dg_owners.ItemsSource = dt.DefaultView;



            dt = db.getData("select * from Driver;");
            CMB_DID.ItemsSource = dt.DefaultView;
            CMB_DID.DisplayMemberPath = "D_ID";
            CMB_DID.SelectedValuePath = "D_ID";

            dt = db.getData("Select * from Driver");
            CMB_DNAME.ItemsSource = dt.DefaultView;
            CMB_DNAME.DisplayMemberPath = "D_name";
            CMB_DNAME.SelectedValuePath = "D_name";
        }

        private void CMB_DID_DropDownClosed(object sender, EventArgs e)
        {
            CMB_DNAME.Text = "";
            DataTable dt = new DataTable();
            dt = db.getData("select D_ID as 'DRIVER ID', D_name as 'NAME',Driver.L_Num as'LICENS NUMBER',Driver.Tel as 'TELEPHONE',Driver.Address as 'ADDRESS'" +
                " from Driver where D_ID = '" + CMB_DID.Text + "'");
            dg_owners.ItemsSource = dt.DefaultView;
        }

        private void CMB_DNAME_DropDownClosed(object sender, EventArgs e)
        {
            CMB_DID.Text = "";
            DataTable dt = new DataTable();
            dt = db.getData("select D_ID as 'DRIVER ID', D_name as 'NAME',Driver.L_Num as'LICENS NUMBER',Driver.Tel as 'TELEPHONE',Driver.Address as 'ADDRESS'" +
                " from Driver where D_name = '" + CMB_DNAME.Text + "'");
            dg_owners.ItemsSource = dt.DefaultView;
        }

        private void btn_view_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = db.getData("select D_ID as 'DRIVER ID', D_name as 'NAME',Driver.L_Num as'LICENS NUMBER',Driver.Tel as 'TELEPHONE',Driver.Address as 'ADDRESS'" +
                " from Driver;");
            dg_owners.ItemsSource = dt.DefaultView;
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            Driver obj = new Driver();
            obj.Show();
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            add_driver obj = new add_driver();
            obj.Show();
        }

        private void btn_home_Click(object sender, RoutedEventArgs e)
        {
            MainWindow obj = new MainWindow();
            obj.Show();
        }

        private void BTN_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
