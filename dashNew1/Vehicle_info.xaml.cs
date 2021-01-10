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
using System.Data;

namespace dashNew1
{
    /// <summary>
    /// Interaction logic for Update_Vehicle.xaml
    /// </summary>
    public partial class Update_Vehicle : Window
    {
        public Update_Vehicle()
        {
            InitializeComponent();
        }
        Connect_DB db = new Connect_DB();

        private void view_vehicle_form_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = db.getData("select L_Plate as 'License No',Year,Make,Model,Category,Cost_Per_Month as 'Monthly Charge(Rs.)',Cost_Per_Week as 'Weekly Charge(Rs.)',Extra_Cost , O_ID as 'Owner ID', Lend_Date as 'Lend Date' , InsID as 'Insurance ID' , S_date as 'Start Date' , E_date as  'Expiery Date' , V_Path as 'File Path' from Vehicle");
            dg_vehicle.ItemsSource = dt.DefaultView;
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            Add_vehicle obj = new Add_vehicle();
            obj.Show();
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            Updt_vehicle obj = new Updt_vehicle();
            obj.Show();
        }

        private void cmb_category_DropDownClosed(object sender, EventArgs e)
        {
            cmb_year.Text = "";
            cmb_make.Text = "";
            DataTable dt = new DataTable();
            dt = db.getData("select L_Plate as 'License No',Year,Make,Model,Category,Cost_Per_Month as 'Monthly Charge(Rs.)',Cost_Per_Week as 'Weekly Charge(Rs.)',Extra_Cost , O_ID as 'Owner ID', Lend_Date as 'Lend Date' , InsID as 'Insurance ID' , S_date as 'Start Date' , E_date as  'Expiery Date' , V_Path as 'File Path' from Vehicle where Category = '" + cmb_category.Text + "'");
            dg_vehicle.ItemsSource = dt.DefaultView;
        }

        private void cmb_make_DropDownClosed(object sender, EventArgs e)
        {
            cmb_category.Text = "";
            cmb_year.Text = "";
            DataTable dt = new DataTable();
            dt = db.getData("select L_Plate as 'License No',Year,Make,Model,Category,Cost_Per_Month as 'Monthly Charge(Rs.)',Cost_Per_Week as 'Weekly Charge(Rs.)',Extra_Cost , O_ID as 'Owner ID', Lend_Date as 'Lend Date' , InsID as 'Insurance ID' , S_date as 'Start Date' , E_date as  'Expiery Date' , V_Path as 'File Path' from Vehicle where Make = '" + cmb_make.Text + "'");
            dg_vehicle.ItemsSource = dt.DefaultView;
        }

        private void cmb_year_DropDownClosed(object sender, EventArgs e)
        {
            cmb_category.Text = "";
            cmb_make.Text = "";
            DataTable dt = new DataTable();
            dt = db.getData("select L_Plate as 'License No',Year,Make,Model,Category,Cost_Per_Month as 'Monthly Charge(Rs.)',Cost_Per_Week as 'Weekly Charge(Rs.)',Extra_Cost , O_ID as 'Owner ID', Lend_Date as 'Lend Date' , InsID as 'Insurance ID' , S_date as 'Start Date' , E_date as  'Expiery Date' , V_Path as 'File Path' from Vehicle where Year = '" + cmb_year.Text + "'");
            dg_vehicle.ItemsSource = dt.DefaultView;
        }

        private void btn_home_Click(object sender, RoutedEventArgs e)
        {
            MainWindow obj = new MainWindow();
            obj.Show();
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
