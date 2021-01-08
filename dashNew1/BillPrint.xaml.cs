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

        private void Window_BillPrint_Loaded(object sender, RoutedEventArgs e)
        {
            dt_current.Content = DateTime.Now.ToShortDateString();
            txt_dt_hand.Text = DateTime.Now.ToShortDateString();
        }

        private void btn_print_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //this.IsEnabled = false;

                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(this, "test");
                }
            }
            finally
            {
               // this.IsEnabled = true;
            }
        }
    }
}
