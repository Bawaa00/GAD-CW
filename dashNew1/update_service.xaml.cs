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
            string a = " update Service set  VNo= '" + txt_vehiclenum.Text + "', s_details = '" + txt_Sdetails.Text + "', " +
                                                  " S_milage=  '" + txt_milge.Text + "', Nxt_milage= '" + txt_nxt.Text + "' where S_ID  = '" + cmb_updateser.Text + "'";



            int line = db.save_update_delete(a);
            if (line == 1)
                MessageBox.Show("Data save Successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

            else
                MessageBox.Show("Data cannot save", "error", MessageBoxButton.OK, MessageBoxImage.Error);
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
            obj.Show();
        }

        private void cmb_updateser_DropDownClosed(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = db.getData("select * from Service where S_ID='" + cmb_updateser.Text + "'");

            txt_vehiclenum.Text = dt.Rows[0][0].ToString();
            txt_Sdetails.Text = dt.Rows[0][2].ToString();
            txt_milge.Text = dt.Rows[0][3].ToString();
            txt_nxt.Text = dt.Rows[0][4].ToString();
        }

        private void BTN_BACK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
