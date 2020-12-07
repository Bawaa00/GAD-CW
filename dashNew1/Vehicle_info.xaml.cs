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
            dt = db.getData("select * from Vehicle");
            dg_vehicle.ItemsSource = dt.DefaultView;
        }
    }
}
