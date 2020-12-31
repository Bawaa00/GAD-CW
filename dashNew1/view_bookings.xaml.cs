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
            cmb_view.ItemsSource = dt.DefaultView;
            cmb_view.DisplayMemberPath = "BK_No";
          cmb_view.SelectedValuePath = "BK_No";

        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            updt_booking obj = new updt_booking();
            obj.Show();
        }

        private void btn_add1_Click(object sender, RoutedEventArgs e)
        {
            Booking obj = new Booking();
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
