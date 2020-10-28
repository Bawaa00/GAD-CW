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

        private void Cars_MouseEnter(object sender, MouseEventArgs e)
        {
            car_option_panel.Visibility = Visibility.Visible;
           // option_panel.Margin = new Thickness(228, 120, 0, 0);
            //opt_1.Text = "    Add New Vehicle"; opt_1.FontSize = 18; opt_1.FontWeight = FontWeights.Medium; opt_1.TextAlignment = TextAlignment.Left;
            //opt_2.Text = "    View Vehicles";
            //opt_3.Text = "    Search and Update or Delete Vehicles";
        }

        private void Cars_MouseLeave(object sender, MouseEventArgs e)
        {
            car_option_panel.Visibility = Visibility.Hidden;
        }

        private void Customers_MouseEnter(object sender, MouseEventArgs e)
        {
            cus_option_panel.Visibility = Visibility.Visible;
            //cus_option_panel.Margin = new Thickness(228, 174, 0, 0);
        }

        private void Customers_MouseLeave(object sender, MouseEventArgs e)
        {
           cus_option_panel.Visibility = Visibility.Hidden;
        }

        private void driver_MouseEnter(object sender, MouseEventArgs e)
        {
            d_option_panel.Visibility = Visibility.Visible;
           // option_panel.Margin = new Thickness(228, 230, 0, 0);
        }

        private void driver_MouseLeave(object sender, MouseEventArgs e)
        {
            d_option_panel.Visibility = Visibility.Hidden;
        }

        private void services_MouseEnter(object sender, MouseEventArgs e)
        {
            s_option_panel.Visibility = Visibility.Visible;
            //option_panel.Margin = new Thickness(228, 286, 0, 0);
        }

        private void services_MouseLeave(object sender, MouseEventArgs e)
        {
            s_option_panel.Visibility = Visibility.Hidden;
        }

        private void repairs_MouseEnter(object sender, MouseEventArgs e)
        {
            repair_option_panel.Visibility = Visibility.Visible;
            //option_panel.Margin = new Thickness(228, 346, 0, 0);
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
    }
}
