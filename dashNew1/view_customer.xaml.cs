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
    /// Interaction logic for view_customer.xaml
    /// </summary>
    public partial class view_customer : Window
    {
        public view_customer()
        {
            InitializeComponent();
        }
        Connect_DB db = new Connect_DB();

        private void view_customer1_Loaded(object sender, RoutedEventArgs e)
        {

            DataTable dt = new DataTable();
            dt = db.getData("select Cus_ID as 'CUSTOMER ID', Customer.F_name as 'FIRST NAME',Customer.S_name as'SURENAME',Customer.Cus_address as 'ADDRESS',Customer.Cus_Tel as 'TELEPHONE',Customer.NIC as 'NIC',Car_Booking.BNO as 'BOOKING ID'" +
                " from Car_Booking,Booking,Vehicle,Driver,Customer" +
                " where BK_No = BNO and CNO = Cus_ID and VNO = L_Plate and DNO = D_ID;");
            dg_owners.ItemsSource = dt.DefaultView;



            dt = db.getData("select * from Customer;");
            CMD_CUSID.ItemsSource = dt.DefaultView;
            CMD_CUSID.DisplayMemberPath = "Cus_ID";
            CMD_CUSID.SelectedValuePath = "Cus_ID";

            dt = db.getData("Select * from Customer");
            CMB_CUSNAME.ItemsSource = dt.DefaultView;
            CMB_CUSNAME.DisplayMemberPath = "F_name";
            CMB_CUSNAME.SelectedValuePath = "Fname";
        }

        private void CMD_CUSID_DropDownClosed(object sender, EventArgs e)
        {
            CMB_CUSNAME.Text = "";
            DataTable dt = new DataTable();
            dt = db.getData("select Cus_ID as 'CUSTOMER ID', Customer.F_name as 'FIRST NAME',Customer.S_name as'SURENAME',Customer.Cus_address as 'ADDRESS',Customer.Cus_Tel as 'TELEPHONE',Customer.NIC as 'NIC',Car_Booking.BNO as 'BOOKING ID',VNO as 'VEHICLE LICEN PLATE',Model  as 'MODEL',D_ID  as 'DRIVER ID',D_name  as 'DRIVER NAME'" +
                " from Car_Booking,Booking,Vehicle,Driver,Customer" +
                " where BK_No = BNO and CNO = Cus_ID and VNO = L_Plate and DNO = D_ID and Cus_ID = '" + CMD_CUSID.Text + "'");
            dg_owners.ItemsSource = dt.DefaultView;
        }

        private void CMB_CUSNAME_DropDownClosed(object sender, EventArgs e)
        {
            CMD_CUSID.Text = "";

            DataTable dt = new DataTable();
            dt = db.getData("select Cus_ID as 'CUSTOMER ID', Customer.F_name as 'FIRST NAME',Customer.S_name as'SURENAME',Customer.Cus_address as 'ADDRESS',Customer.Cus_Tel as 'TELEPHONE',Customer.NIC as 'NIC',Car_Booking.BNO as 'BOOKING ID',VNO as 'VEHICLE LICEN PLATE',Model  as 'MODEL',D_ID  as 'DRIVER ID',D_name  as 'DRIVER NAME'" +
                " from Car_Booking,Booking,Vehicle,Driver,Customer" +
                " where BK_No = BNO and CNO = Cus_ID and VNO = L_Plate and DNO = D_ID and F_name='" + CMB_CUSNAME.Text + "'");
            dg_owners.ItemsSource = dt.DefaultView;
        }

        private void btn_view_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = db.getData("select Cus_ID as 'CUSTOMER ID', Customer.F_name as 'FIRST NAME',Customer.S_name as'SURENAME',Customer.Cus_address as 'ADDRESS',Customer.Cus_Tel as 'TELEPHONE',Customer.NIC as 'NIC',Car_Booking.BNO as 'BOOKING ID',VNO as 'VEHICLE LICEN PLATE',Model  as 'MODEL',D_ID  as 'DRIVER ID',D_name  as 'DRIVER NAME'" +
                " from Car_Booking,Booking,Vehicle,Driver,Customer" +
                " where BK_No = BNO and CNO = Cus_ID and VNO = L_Plate and DNO = D_ID;");
            dg_owners.ItemsSource = dt.DefaultView;
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            update_customer obj = new update_customer();
            obj.Show();
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            addCustomer obj = new addCustomer();
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
