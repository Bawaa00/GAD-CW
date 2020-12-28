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
    /// Interaction logic for Update_ownr.xaml
    /// </summary>
    public partial class Update_ownr : Window
    {
        public Update_ownr()
        {
            InitializeComponent();
        }
        Connect_DB db = new Connect_DB();
        string path;
       
        private void form_up_owner_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = db.getData("select * from Owner");
            cmb_oid.ItemsSource = dt.DefaultView;
            cmb_oid.DisplayMemberPath = "O_ID";
            cmb_oid.SelectedValuePath = "O_ID";
        }

        private void cmb_oid_DropDownClosed(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = db.getData("select * from Owner where O_ID = '"+cmb_oid.Text+"'");
            txt_nic.Text = dt.Rows[0][1].ToString();
            txt_name.Text = dt.Rows[0][2].ToString();
            txt_address.Text = dt.Rows[0][3].ToString();
            txt_contact.Text = dt.Rows[0][4].ToString();
            path = dt.Rows[0][5].ToString();
            ImageSource imgsource = new BitmapImage(new Uri(path));
            img_owner.Source = imgsource;
        }
    }
}
