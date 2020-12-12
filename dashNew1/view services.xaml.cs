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
    /// Interaction logic for view_services.xaml
    /// </summary>
    public partial class view_services : Window
    {
        public view_services()
        {
            InitializeComponent();
        }

        Connect_DB db = new Connect_DB();

        private void view_services_form_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = db.getData("select * from Service");
            dg_service.ItemsSource = dt.DefaultView;


        }

        private void btn_view_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = db.getData("select * from Service");
            dg_service.ItemsSource = dt.DefaultView;
        }
    }
}
