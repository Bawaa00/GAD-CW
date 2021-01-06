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
    /// Interaction logic for Messagebox.xaml
    /// </summary>
    public partial class Messagebox : Window
    {
        public Messagebox()
        {
            InitializeComponent();
        }

        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void errorMsg(string msg)
        {
            icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.Error;
            txt_msg.Text = msg;
        }

        public void warningMsg(string msg)
        {
            icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.Warning;
            txt_msg.Text = msg;
        }

        public void confimationMsg(string msg)
        {
            btn_cancel.Visibility = Visibility.Visible;
            icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.Report;
            txt_msg.Text = msg;
        }

        public void informationMsg(string msg)
        {
            icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.InfoCircle;
            txt_msg.Text = msg;
        }

    }
}
