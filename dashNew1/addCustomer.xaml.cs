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
using System.Data.SqlClient;

namespace dashNew1
{
    /// <summary>
    /// Interaction logic for addCustomer.xaml
    /// </summary>
    public partial class addCustomer : Window
    {
        public addCustomer()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlCommand cmd;

        private void Add_Customer_Loaded(object sender, RoutedEventArgs e)
        {
            con = new SqlConnection("Data Source=DESKTOP-USKQUER;Initial Catalog=TaxiService;Integrated Security=True");
        }



        private void btn_submit_Click(object sender, RoutedEventArgs e)
        {
            string id, fName, lName, address, L_No, NIC;
            id = txt_id.Text;
            fName = txt_fName.Text;
            lName = txt_lName.Text;
            address = txt_LicNum.Text;
            L_No = txt_LicNum.Text;
            NIC = txt_NIC.Text;
        }
    }
}

