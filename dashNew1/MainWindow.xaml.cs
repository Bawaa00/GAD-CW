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

        private void Dashboard_MouseEnter(object sender, MouseEventArgs e)
        {

        }
    }
}
