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
    /// Interaction logic for BillPrint.xaml
    /// </summary>
    public partial class BillPrint : Window
    {
        public BillPrint()
        {
            InitializeComponent();
        }

        Connect_DB db = new Connect_DB();

        private void Window_BillPrint_Loaded(object sender, RoutedEventArgs e)
        {
            dt_current.Content = DateTime.Now.ToShortDateString();
            txt_dt_hand.Text = DateTime.Now.ToShortDateString();
        }

        private void btn_print_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                btn_cal.Visibility = Visibility.Hidden;
                btn_print.Visibility = Visibility.Hidden;

                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(this, "test");
                }
            }
            finally
            {
                btn_cal.Visibility = Visibility.Visible;
                btn_print.Visibility = Visibility.Visible;
            }
        }

        private void btn_cal_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = db.getData("select * from Vehicle where L_Plate = '" + txt_lplate.Text + "'");

            System.TimeSpan diff = Convert.ToDateTime(txt_dt_lend.Text) - Convert.ToDateTime(txt_dt_pick.Text);

            int allo = (diff.Days * 100);
            txt_allo.Text = allo.ToString();
            //int km = Convert.ToInt32(txt_km.Text);
            int extra_km = Convert.ToInt32(txt_km.Text) - allo ;
            if (extra_km<0)
            {
                extra_km = 0;
            }
            txt_km_extra.Text = extra_km.ToString();
            int per_mile = Convert.ToInt32(dt.Rows[0][7]);
            txt_extra.Text = (Convert.ToInt32(txt_km_extra.Text) * per_mile ).ToString();
            if(diff.Days < 30)
            {
                txt_tot.Text = ((Convert.ToInt32(dt.Rows[0][6])* (diff.Days / 7)) + Convert.ToInt32(txt_extra.Text)).ToString();
            }
            else 
            {
                txt_tot.Text = ((Convert.ToInt32(dt.Rows[0][5]) * (diff.Days / 30)) + Convert.ToInt32(txt_extra.Text)).ToString();
            }
            txt_pay.Text = (Convert.ToInt32(txt_tot.Text) - Convert.ToInt32(txt_adv_pay.Text)).ToString();
        }
    }
}
