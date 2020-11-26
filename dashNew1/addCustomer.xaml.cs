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
            con.Open();
            cmd = new SqlCommand("Insert into customer values ('" + txt_id.Text + "','" + txt_fName.Text + "'," +
                "'" + txt_lName.Text + "','" + txt_address.Text + "','" + txt_LicNum.Text + "','" + txt_NIC.Text + "')", con);
            int i = cmd.ExecuteNonQuery();
            if(i == 1)
                MessageBox.Show("Data save Successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("Data cannot save", "error", MessageBoxButton.OK, MessageBoxImage.Error);
            con.Close();
            cmd.Dispose();

        }
    }
}

