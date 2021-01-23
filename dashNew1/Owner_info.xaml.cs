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
    /// Interaction logic for Owner_info.xaml
    /// </summary>
    public partial class Owner_info : Window
    {
        public Owner_info()
        {
            InitializeComponent();
        }

        Connect_DB db = new Connect_DB();

        private void dg_owners_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            dt=db.getData("select * from Owner");
            dg_owners.ItemsSource = dt.DefaultView;
        }

        private void form_owner_info_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = db.getData("select * from Owner;");
            cmb_oid.ItemsSource = dt.DefaultView;
            cmb_oid.DisplayMemberPath = "O_ID";
            cmb_oid.SelectedValuePath = "O_ID";
        }

        private void cmb_oid_DropDownClosed(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = db.getData("select * from Owner where O_ID = '"+cmb_oid.Text+"' ");
            dg_owners.ItemsSource = dt.DefaultView;
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            Update_ownr obj = new Update_ownr();
            obj.Show();
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            Add_owner obj = new Add_owner();
            obj.Show();
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
    }
}
