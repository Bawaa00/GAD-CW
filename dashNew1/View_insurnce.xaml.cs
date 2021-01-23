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
    /// Interaction logic for View_insurnce.xaml
    /// </summary>
    public partial class View_insurnce : Window
    {
        public View_insurnce()
        {
            InitializeComponent();
        }
        Connect_DB db = new Connect_DB();
        string id;

        private void view_ins_form_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = db.getData("select I_ID as 'Insurance ID' ,I_company as 'Company',I_Address as 'Address' ,I_Telephone as 'Contact' from Insurance");
            dg_ins.ItemsSource = dt.DefaultView;

            dt = db.getData("select * from Insurance");
            cmb_id.ItemsSource = dt.DefaultView;
            cmb_id.DisplayMemberPath = "I_ID";
            cmb_id.SelectedValuePath = "I_ID";
        }

        private void cmb_id_DropDownClosed(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = db.getData("select I_ID as 'Insurance ID' ,I_company as 'Company',I_Address as 'Address' ,I_Telephone as 'Contact' from Insurance where I_ID = '"+cmb_id.Text+"'");
            dg_ins.ItemsSource = dt.DefaultView;
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            Add_Insurnce obj = new Add_Insurnce();
            obj.Show();
        }

        private void btn_del_Click(object sender, RoutedEventArgs e)
        {
            id = dg_ins.SelectedValue.ToString();
           int i = db.save_update_delete("delete from Insurance where I_ID = '" + id + "'");
            if (i == 1)
                MessageBox.Show("Data Deleted Successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

            else
                MessageBox.Show("Data cannot Delete", "error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void dg_ins_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_home_Click(object sender, RoutedEventArgs e)
        {
            MainWindow obj = new MainWindow();
            this.Close();
            obj.Show();
        }
    }
}
