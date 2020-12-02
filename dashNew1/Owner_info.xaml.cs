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
    }
}
