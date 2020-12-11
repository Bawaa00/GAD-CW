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
using System.Text.RegularExpressions;

namespace dashNew1
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }
        Connect_DB db = new Connect_DB();
        Hashcode hc = new Hashcode();
        private void btn_submit_Click(object sender, RoutedEventArgs e)
        {
            int i = db.save_update_delete("insert into User_Login (Uname,Upass,Fname,Lname) values ('" + txt_uname.Text + "','" + hc.PassHash(pbox_pass.Password) + "','" + txt_fname.Text + "','" + txt_lname.Text + "')");
            if (i == 1)
            {
                MessageBox.Show("Data saved successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
                MessageBox.Show("Data not saved", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void md_icon_MouseEnter(object sender, MouseEventArgs e)
        {
            md_icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.CloseCircleOutline;
            md_elipse.Fill = Brushes.Red;
        }

        private void pbox_pass_KeyUp(object sender, KeyEventArgs e)
        {
            if (!Regex.IsMatch(pbox_pass.Password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$"))
            {
                txt_info.Visibility = Visibility.Visible;
                md_elipse.Visibility = Visibility.Visible;
                md_icon.Visibility = Visibility.Visible;
                md_icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.CloseCircleOutline;
                md_elipse.Fill = Brushes.Red;
                txt_info.Foreground = Brushes.Red;
                txt_info.Text = "Invalid Password";
                pbox_pass.Focus();
            }
            else
            {
                md_elipse.Visibility = Visibility.Visible;
                md_icon.Visibility = Visibility.Visible;
                md_icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.CheckCircleOutline;
                md_elipse.Fill = Brushes.Green;
                txt_info.Visibility = Visibility.Visible;
                txt_info.Foreground = Brushes.Green;
                txt_info.Text = "Valid Password";
            }
        }

        private void pbox_pass_LostFocus(object sender, RoutedEventArgs e)
        {
            md_elipse.Visibility = Visibility.Hidden;
            txt_info.Visibility = Visibility.Hidden;
        }

        private void pbox_retype_KeyUp(object sender, KeyEventArgs e)
        {
            if (pbox_pass.Password!=pbox_retype.Password)
            {
                txt_info.Visibility = Visibility.Visible;
                md_elipse.Visibility = Visibility.Visible;
                md_icon.Visibility = Visibility.Visible;
                md_icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.CloseCircleOutline;
                md_elipse.Fill = Brushes.Red;
                txt_info.Foreground = Brushes.Red;
                txt_info.Text = "Passwords do not match";
                pbox_retype.Focus();
            }
            else if (pbox_pass.Password == pbox_retype.Password)
            {
                md_elipse.Visibility = Visibility.Visible;
                md_icon.Visibility = Visibility.Visible;
                md_icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.CheckCircleOutline;
                md_elipse.Fill = Brushes.Green;
                txt_info.Visibility = Visibility.Visible;
                txt_info.Foreground = Brushes.Green;
                txt_info.Text = "Passwords Match";
            }
        }

        private void pbox_retype_LostFocus(object sender, RoutedEventArgs e)
        {
            md_elipse.Visibility = Visibility.Hidden;
            txt_info.Visibility = Visibility.Hidden;
        }

        private void txt_fname_KeyUp(object sender, KeyEventArgs e)
        {
            if (!Regex.IsMatch(txt_fname.Text, @"^^[a-zA-Z]+$"))
            {
                txt_info.Visibility = Visibility.Visible;
                md_elipse.Visibility = Visibility.Visible;
                md_icon.Visibility = Visibility.Visible;
                md_icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.CloseCircleOutline;
                md_elipse.Fill = Brushes.Red;
                txt_info.Foreground = Brushes.Red;
                txt_info.Text = "Invalid Name";
                txt_fname.Focus();
            }
            else if (txt_fname.Text.Length==0)
            {
                txt_info.Visibility = Visibility.Visible;
                md_elipse.Visibility = Visibility.Visible;
                md_icon.Visibility = Visibility.Visible;
                md_icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.CloseCircleOutline;
                md_elipse.Fill = Brushes.Red;
                txt_info.Foreground = Brushes.Red;
                txt_info.Text = "Cannot be blank";
                txt_fname.Focus();
            }
            else
            {
                md_elipse.Visibility = Visibility.Visible;
                md_icon.Visibility = Visibility.Visible;
                md_icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.CheckCircleOutline;
                md_elipse.Fill = Brushes.Green;
                txt_info.Visibility = Visibility.Visible;
                txt_info.Foreground = Brushes.Green;
                txt_info.Text = "Valid Name";
            }
        }

        private void txt_fname_LostFocus(object sender, RoutedEventArgs e)
        {
            md_elipse.Visibility = Visibility.Hidden;
            txt_info.Visibility = Visibility.Hidden;
        }

        private void txt_lname_KeyUp(object sender, KeyEventArgs e)
        {
            if (!Regex.IsMatch(txt_lname.Text, @"^^[a-zA-Z]+$"))
            {
                txt_info.Visibility = Visibility.Visible;
                md_elipse.Visibility = Visibility.Visible;
                md_icon.Visibility = Visibility.Visible;
                md_icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.CloseCircleOutline;
                md_elipse.Fill = Brushes.Red;
                txt_info.Foreground = Brushes.Red;
                txt_info.Text = "Invalid Name";
                txt_lname.Focus();
            }
            else if (txt_fname.Text.Length == 0)
            {
                txt_info.Visibility = Visibility.Visible;
                md_elipse.Visibility = Visibility.Visible;
                md_icon.Visibility = Visibility.Visible;
                md_icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.CloseCircleOutline;
                md_elipse.Fill = Brushes.Red;
                txt_info.Foreground = Brushes.Red;
                txt_info.Text = "Cannot be blank";
                txt_lname.Focus();
            }
            else
            {
                md_elipse.Visibility = Visibility.Visible;
                md_icon.Visibility = Visibility.Visible;
                md_icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.CheckCircleOutline;
                md_elipse.Fill = Brushes.Green;
                txt_info.Visibility = Visibility.Visible;
                txt_info.Foreground = Brushes.Green;
                txt_info.Text = "Valid Name";
            }
        }

        private void txt_lname_LostFocus(object sender, RoutedEventArgs e)
        {
            md_elipse.Visibility = Visibility.Hidden;
            txt_info.Visibility = Visibility.Hidden;
        }

        private void txt_uname_KeyUp(object sender, KeyEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = db.getData("select * from User_Login where Uname = '"+txt_uname.Text+"'");
            if (dt.Rows.Count == 1)
            {
                txt_info.Visibility = Visibility.Visible;
                md_elipse.Visibility = Visibility.Visible;
                md_icon.Visibility = Visibility.Visible;
                md_icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.CloseCircleOutline;
                md_elipse.Fill = Brushes.Red;
                txt_info.Foreground = Brushes.Red;
                txt_info.Text = "Sorry Username already taken";
                txt_uname.Focus();
            }
            else
            {
                md_elipse.Visibility = Visibility.Visible;
                md_icon.Visibility = Visibility.Visible;
                md_icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.CheckCircleOutline;
                md_elipse.Fill = Brushes.Green;
                txt_info.Visibility = Visibility.Visible;
                txt_info.Foreground = Brushes.Green;
                txt_info.Text = "Valid Username";
            }
        }

        private void txt_uname_LostFocus(object sender, RoutedEventArgs e)
        {
            md_elipse.Visibility = Visibility.Hidden;
            txt_info.Visibility = Visibility.Hidden;
        }
    }

}

