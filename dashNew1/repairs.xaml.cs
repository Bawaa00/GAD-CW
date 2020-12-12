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
    /// Interaction logic for repairs.xaml
    /// </summary>
    public partial class repairs : Window
    {
        public repairs()
        {
            InitializeComponent();
        }

        Connect_DB db = new Connect_DB();
        DataTable dt = new DataTable();
        private void btn_view_Click(object sender, RoutedEventArgs e)
        {
            if (cmb_type.SelectedIndex == 0)
            {
                dt = db.getData("exec view_maintenance");
                dg_repair.ItemsSource = dt.DefaultView;
            }
            else if (cmb_type.SelectedIndex == 1)
            {
                dt = db.getData("exec view_accident");
                dg_repair.ItemsSource = dt.DefaultView;
            }

        }

        private void view_repair_form_Loaded(object sender, RoutedEventArgs e)
        {
            dt = db.getData("select * from Vehicle");
            cmb_vid.ItemsSource = dt.DefaultView;
            cmb_vid.DisplayMemberPath = "L_Plate";
            cmb_vid.SelectedValuePath = "L_Plate";
        }

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            if (cmb_type.SelectedIndex == 0)
            {
                dt = db.getData("exec search_maintenance '"+cmb_vid.Text+"'");
                dg_repair.ItemsSource = dt.DefaultView;
            }
            else if (cmb_type.SelectedIndex == 1)
            {
                dt = db.getData("exec search_accident '"+cmb_vid.Text+"'");
                dg_repair.ItemsSource = dt.DefaultView;
            }
        }

        private void btn_lat_Click(object sender, RoutedEventArgs e)
        {
            if (cmb_type.SelectedIndex == 0)
            {
                dt = db.getData("exec search_latest_maintenance '"+cmb_vid.Text+"'");
                dg_repair.ItemsSource = dt.DefaultView;
            }
            else if (cmb_type.SelectedIndex == 1)
            {
                dt = db.getData("exec search_latest_accident '"+cmb_vid.Text+"'");
                dg_repair.ItemsSource = dt.DefaultView;
            }
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            add_repairs obj = new add_repairs();
            obj.Show();
        }
    }
}
