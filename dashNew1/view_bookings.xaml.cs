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
    /// Interaction logic for view_bookings.xaml
    /// </summary>
    public partial class view_bookings : Window
    {
        public view_bookings()
        {
            InitializeComponent();
        }
        Connect_DB db = new Connect_DB();

        private void view_booking_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();  
           dt = db.getData("select BK_No as 'BOOK ID', BK_date as 'BOOK DATE', Booking.S_date as'PICKUP DATE',L_date as 'LEND DATE',Cus_ID as 'CUSTOMER ID',F_name as 'FIRST NAME',S_name as 'SURENAME',L_Plate as 'LICEN PLATE',Make  as 'MAKE',Model  as 'MODEL',D_ID  as 'DRIVER ID',D_name  as 'DRIVER NAME'" +
               " from Car_Booking,Booking,Vehicle,Driver,Customer" +
               " where BK_No = BNO and CNO = Cus_ID and VNO = L_Plate and DNO = D_ID;");
            dg_owners.ItemsSource = dt.DefaultView;

            dt = db.getData("select * from Booking;") ;
            cmb_bkid.ItemsSource = dt.DefaultView;
            cmb_bkid.DisplayMemberPath = "BK_No";
            cmb_bkid.SelectedValuePath = "BK_No";

            dt = db.getData("Select * from Customer");
            cmb_cusno.ItemsSource = dt.DefaultView;
            cmb_cusno.DisplayMemberPath = "Cus_ID";
            cmb_cusno.SelectedValuePath = "Cus_ID";

            dt = db.getData("Select * from Vehicle");
            cmb_lpate.ItemsSource = dt.DefaultView;
            cmb_lpate.DisplayMemberPath = "L_Plate";
            cmb_lpate.SelectedValuePath = "L_Plate";

        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            updt_booking obj = new updt_booking();
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

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            Booking obj = new Booking();
            obj.Show();
        }

        private void cmb_bkid_DropDownClosed(object sender, EventArgs e)
        {
            cmb_cusno.Text = "";
            cmb_lpate.Text = "";

            DataTable dt = new DataTable();
            dt = db.getData("select BK_No as 'BOOK ID', BK_date as 'BOOK DATE', Booking.S_date as'PICKUP DATE',L_date as 'LEND DATE',Cus_ID as 'CUSTOMER ID',F_name as 'FIRST NAME',S_name as 'SURENAME',L_Plate as 'LICEN PLATE',Make  as 'MAKE',Model  as 'MODEL',D_ID  as 'DRIVER ID',D_name  as 'DRIVER NAME'" +
                " from Car_Booking,Booking,Vehicle,Driver,Customer" +
                " where BK_No = BNO and CNO = Cus_ID and VNO = L_Plate and DNO = D_ID and BK_No='"+cmb_bkid.Text+"'");
            dg_owners.ItemsSource = dt.DefaultView;
        }

        private void cmb_lpate_DropDownClosed(object sender, EventArgs e)
        {
            cmb_cusno.Text = "";
            cmb_bkid.Text = "";
            DataTable dt = new DataTable();
            dt = db.getData("select BK_No as 'BOOK ID', BK_date as 'BOOK DATE', Booking.S_date as'PICKUP DATE',L_date as 'LEND DATE',Cus_ID as 'CUSTOMER ID',F_name as 'FIRST NAME',S_name as 'SURENAME',L_Plate as 'LICEN PLATE',Make  as 'MAKE',Model  as 'MODEL',D_ID  as 'DRIVER ID',D_name  as 'DRIVER NAME'" +
                " from Car_Booking,Booking,Vehicle,Driver,Customer" +
                " where BK_No = BNO and CNO = Cus_ID and VNO = L_Plate and DNO = D_ID and L_Plate = '"+cmb_lpate.Text+"'");
            dg_owners.ItemsSource = dt.DefaultView;
        }

        private void cmb_cusno_DropDownClosed(object sender, EventArgs e)
        {
            cmb_bkid.Text = "";
            cmb_lpate.Text = "";
            DataTable dt = new DataTable();
            dt = db.getData("select BK_No as 'BOOK ID', BK_date as 'BOOK DATE', Booking.S_date as'PICKUP DATE',L_date as 'LEND DATE',Cus_ID as 'CUSTOMER ID',F_name as 'FIRST NAME',S_name as 'SURENAME',L_Plate as 'LICEN PLATE',Make  as 'MAKE',Model  as 'MODEL',D_ID  as 'DRIVER ID',D_name  as 'DRIVER NAME'" +
                " from Car_Booking,Booking,Vehicle,Driver,Customer" +
                " where BK_No = BNO and CNO = Cus_ID and VNO = L_Plate and DNO = D_ID and Cus_ID = '"+cmb_cusno.Text+"'");
            dg_owners.ItemsSource = dt.DefaultView;
        }

        private void btn_view_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = db.getData("select BK_No as 'BOOK ID', BK_date as 'BOOK DATE', Booking.S_date as'PICKUP DATE',L_date as 'LEND DATE',Cus_ID as 'CUSTOMER ID',F_name as 'FIRST NAME',S_name as 'SURENAME',L_Plate as 'LICEN PLATE',Make  as 'MAKE',Model  as 'MODEL',D_ID  as 'DRIVER ID',D_name  as 'DRIVER NAME'" +
                " from Car_Booking,Booking,Vehicle,Driver,Customer" +
                " where BK_No = BNO and CNO = Cus_ID and VNO = L_Plate and DNO = D_ID ");
            dg_owners.ItemsSource = dt.DefaultView;
        }
    }
}
