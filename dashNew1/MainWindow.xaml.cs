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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace dashNew1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        double panelWidth;
        Brush tab;
        bool hidden=true;
        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(10);
            timer.Tick += Timer_Tick;

            panelWidth = sidePanel.Width;
            sidePanel.Width = 50;            
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if(hidden==true)
            {
                sidePanel.Width += 1;
                if(sidePanel.Width >= panelWidth)
                {
                    timer.Stop();
                    hidden = false;  
                }
            }
            else
            {
                sidePanel.Width -= 1;
                if (sidePanel.Width <= 50)
                {
                    timer.Stop();
                    hidden = true;
                }

            }
        }

        private void SidePanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton==MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        /*private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }*/

      

        private void collapse(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }
        
        private void Cars_MouseDown(object sender, MouseButtonEventArgs e)
        {
            car_option_panel.Visibility = Visibility.Visible;
        }

        private void Cars_MouseLeave(object sender, MouseEventArgs e)
        {
            car_option_panel.Visibility = Visibility.Hidden;
        }

        private void Customers_MouseDown(object sender, MouseButtonEventArgs e)
        {
            cus_option_panel.Visibility = Visibility.Visible;
        }

        private void Customers_MouseLeave(object sender, MouseEventArgs e)
        {
           cus_option_panel.Visibility = Visibility.Hidden;
        }

       private void driver_MouseDown(object sender, MouseButtonEventArgs e)
        {
            d_option_panel.Visibility = Visibility.Visible;
        }
        private void driver_MouseLeave(object sender, MouseEventArgs e)
        {
            d_option_panel.Visibility = Visibility.Hidden;
        }

        private void services_MouseDown(object sender, MouseButtonEventArgs e)
        {
            s_option_panel.Visibility = Visibility.Visible;
        }

        private void services_MouseLeave(object sender, MouseEventArgs e)
        {
            s_option_panel.Visibility = Visibility.Hidden;
        }

        private void repairs_MouseDown(object sender, MouseButtonEventArgs e)
        {
            repair_option_panel.Visibility = Visibility.Visible;
        }

        private void repairs_MouseLeave(object sender, MouseEventArgs e)
        {
            repair_option_panel.Visibility = Visibility.Hidden;
        }

        private void cus_option_panel_MouseEnter(object sender, MouseEventArgs e)
        {
            cus_option_panel.Visibility = Visibility.Visible;
        }

        private void cus_option_panel_MouseLeave(object sender, MouseEventArgs e)
        {
            cus_option_panel.Visibility = Visibility.Hidden;
        }

        private void car_option_panel_MouseEnter(object sender, MouseEventArgs e)
        {
            car_option_panel.Visibility = Visibility.Visible;
        }

        private void car_option_panel_MouseLeave(object sender, MouseEventArgs e)
        {
            car_option_panel.Visibility = Visibility.Hidden;
        }

        private void d_option_panel_MouseEnter(object sender, MouseEventArgs e)
        {
            d_option_panel.Visibility = Visibility.Visible;
        }

        private void d_option_panel_MouseLeave(object sender, MouseEventArgs e)
        {
            d_option_panel.Visibility = Visibility.Hidden;
        }

        private void s_option_panel_MouseEnter(object sender, MouseEventArgs e)
        {
            s_option_panel.Visibility = Visibility.Visible;
        }

        private void s_option_panel_MouseLeave(object sender, MouseEventArgs e)
        {
            s_option_panel.Visibility = Visibility.Hidden;
        }

        private void repair_option_panel_MouseEnter(object sender, MouseEventArgs e)
        {
            repair_option_panel.Visibility = Visibility.Visible;
        }

        private void reapair_option_panel_MouseLeave(object sender, MouseEventArgs e)
        {
            repair_option_panel.Visibility = Visibility.Hidden;
        }

        private void v_opt1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Add_vehicle obj = new Add_vehicle();
           // this.Hide();
            obj.Show();
        }

        private void v_opt2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            View_car obj = new View_car();
            //this.Hide();
            obj.Show();
        }

        private void c_opt1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            addCustomer obj = new addCustomer();
            //this.Hide();
            obj.Show();
        }

        private void d_opt3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Driver obj = new Driver();
           // this.Hide();
            obj.Show();
        }

        private void s_opt1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Services obj = new Services();
            obj.Show();
        }

        private void s_opt2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            view_services obj = new view_services();
            obj.Show();
        }

        private void r_opt1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            add_repairs obj = new add_repairs();
            obj.Show();
        }

        private void r_opt2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            repairs obj = new repairs();
            obj.Show();
        }

        private void v_opt4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Booking obj = new Booking();
            obj.Show();
        }

        private void v_opt3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Updt_vehicle obj = new Updt_vehicle();
            obj.Show();
        }
    }
}
