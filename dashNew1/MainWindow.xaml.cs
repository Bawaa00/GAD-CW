﻿using System;
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
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Charts;
using System.Data;

namespace dashNew1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.PieChart();
            labelData();
        }

        Connect_DB db = new Connect_DB();
        voiceCommands vc = new voiceCommands();
        public Func<ChartPoint, string> PointLabel { get; set; }

        public void PieChart()
        {
            PointLabel = chartPoint => string.Format("{0}({1:P})", chartPoint.Y, chartPoint.Participation);
            DataContext = this;
        }

        public void labelData()
        {

            string path;
            DataTable dt = new DataTable();
            dt = db.getData("select COUNT(L_Plate) from Vehicle");
            label_vehicle.Content = dt.Rows[0][0].ToString();
            dt = db.getData("select COUNT(D_ID) from Driver");
            label_driver.Content = dt.Rows[0][0].ToString();
            dt = db.getData("select COUNT(Cus_ID) from Customer");
            label_customer.Content = dt.Rows[0][0].ToString();

            try
            {
                string lnum;
                dt = db.getData("select L_Plate,COUNT(L_Plate) from Car_Booking,Vehicle where L_Plate = VNO group by L_Plate");
                lnum = dt.Rows[0][0].ToString();
                dt = db.getData("select * from Vehicle where L_Plate = '" + lnum + "'");
                lbl_year.Content = dt.Rows[0][1].ToString();
                lbl_make.Content = dt.Rows[0][2].ToString();
                lbl_model.Content = dt.Rows[0][3].ToString();
                lbl_cat.Content = dt.Rows[0][4].ToString();
                path = dt.Rows[0][13].ToString();
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = new Uri(path);
                image.EndInit();
                img_vehicle.Source = image;
            }
            catch(IndexOutOfRangeException)
            {
                Messagebox obj = new Messagebox();
                obj.errorMsg("Database Error");
                obj.Show();
            }
            catch(Exception ex)
            {
                Messagebox msg = new Messagebox();
                msg.errorMsg("Oops soomething went worng. " + ex.Message);
                msg.Show();
            }
        }

        //Side Panel Buttons

        private void Cars_MouseDown(object sender, MouseButtonEventArgs e)
        {
            car_option_panel.Visibility = Visibility.Visible;
        }
        private void Cars_MouseLeave(object sender, MouseEventArgs e)
        {
            car_option_panel.Visibility = Visibility.Hidden;
        }
        private void car_option_panel_MouseEnter(object sender, MouseEventArgs e)
        {
            car_option_panel.Visibility = Visibility.Visible;
        }
        private void car_option_panel_MouseLeave(object sender, MouseEventArgs e)
        {
            car_option_panel.Visibility = Visibility.Hidden;
        }

        private void Customers_MouseLeave(object sender, MouseEventArgs e)
        {
            cus_option_panel.Visibility = Visibility.Hidden;
        }
        private void cus_option_panel_MouseEnter(object sender, MouseEventArgs e)
        {
            cus_option_panel.Visibility = Visibility.Visible;
        }
        private void Customers_MouseDown(object sender, MouseButtonEventArgs e)
        {
            cus_option_panel.Visibility = Visibility.Visible;
        }
        private void cus_option_panel_MouseLeave(object sender, MouseEventArgs e)
        {
            cus_option_panel.Visibility = Visibility.Hidden;
        }

        private void driver_MouseDown(object sender, MouseButtonEventArgs e)
        {
            d_option_panel.Visibility = Visibility.Visible;
        }
        private void d_option_panel_MouseLeave(object sender, MouseEventArgs e)
        {
            d_option_panel.Visibility = Visibility.Hidden;
        }
        private void d_option_panel_MouseEnter(object sender, MouseEventArgs e)
        {
            d_option_panel.Visibility = Visibility.Visible;
        }
        private void driver_MouseLeave(object sender, MouseEventArgs e)
        {
            d_option_panel.Visibility = Visibility.Hidden;
        }


        private void s_option_panel_MouseLeave(object sender, MouseEventArgs e)
        {
            s_option_panel.Visibility = Visibility.Hidden;
        }
        private void services_MouseLeave(object sender, MouseEventArgs e)
        {
            s_option_panel.Visibility = Visibility.Hidden;
        }
        private void s_option_panel_MouseEnter(object sender, MouseEventArgs e)
        {
            s_option_panel.Visibility = Visibility.Visible;
        }
        private void services_MouseDown(object sender, MouseButtonEventArgs e)
        {
            s_option_panel.Visibility = Visibility.Visible;
        }

        private void reapair_option_panel_MouseLeave(object sender, MouseEventArgs e)
        {
            repair_option_panel.Visibility = Visibility.Hidden;
        }
        private void repairs_MouseLeave(object sender, MouseEventArgs e)
        {
            repair_option_panel.Visibility = Visibility.Hidden;
        }
        private void repair_option_panel_MouseEnter(object sender, MouseEventArgs e)
        {
            repair_option_panel.Visibility = Visibility.Visible;
        }
        private void repairs_MouseDown(object sender, MouseButtonEventArgs e)
        {
            repair_option_panel.Visibility = Visibility.Visible;
        }

        //Vehicle Sub Menu

        private void v_opt1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Add_vehicle obj = new Add_vehicle();
            this.Close();
            obj.Show();
        }

        private void v_opt2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Update_Vehicle obj = new Update_Vehicle();
            this.Close();
            obj.Show();
        }

        private void v_opt3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Updt_vehicle obj = new Updt_vehicle();
            this.Close();
            obj.Show();
        }

        private void v_opt4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Booking obj = new Booking();
            this.Close();
            obj.Show();
        }

        //Customer Sub Menu

        private void c_opt1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            addCustomer obj = new addCustomer();
            this.Close();
            obj.Show();
        }

        private void c_opt2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            view_customer obj = new view_customer();
            this.Close();
            obj.Show();
        }

        private void c_opt3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            update_customer obj = new update_customer();
            this.Close();
            obj.Show();
        }

        private void c_opt4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            view_bookings obj = new view_bookings();
            this.Close();
            obj.Show();
        }

        //Driver Sub Menu

        private void d_opt1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            add_driver obj = new add_driver();
            this.Close();
            obj.Show();
        }


        private void d_opt2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            view_driver obj = new view_driver();
            this.Close();
            obj.Show();
        }

        private void d_opt3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Driver obj = new Driver();
            this.Close();
            obj.Show();
        }

        //Service Sub Menu

        private void s_opt1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Services obj = new Services();
            this.Close();
            obj.Show();
        }

        private void s_opt2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            view_services obj = new view_services();
            this.Close();
            obj.Show();
        }

        private void s_opt3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            update_service obj = new update_service();
            this.Close();
            obj.Show();
        }



        private void s_opt4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ServiceReport obj = new ServiceReport();
            obj.Show();
        }

        //Repair Sub Menu

        private void r_opt1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            add_repairs obj = new add_repairs();
            this.Close();
            obj.Show();
        }

        private void r_opt2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            repairs obj = new repairs();
            this.Close();
            obj.Show();
        }


        private void r_opt3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            update_repair obj = new update_repair();
            this.Close();
            obj.Show();
        }

        private void r_opt4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MaintenanceReport obj = new MaintenanceReport();
            obj.Show();
        }

        private void r_opt5_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AccidentReport obj = new AccidentReport();
            obj.Show();
        }

        //Account Sub Menu

        private void a_opt1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Registration obj = new Registration();
            obj.Show();
        }

        private void acnt_option_panel_MouseLeave(object sender, MouseEventArgs e)
        {
            acnt_option_panel.Visibility = Visibility.Collapsed;
        }

        private void btn_acnt_Click(object sender, RoutedEventArgs e)
        {
            acnt_option_panel.Visibility = Visibility.Visible;
        }

        //Dashboard View Cards

        private void btn_v_vehicle_Click(object sender, RoutedEventArgs e)
        {
            Update_Vehicle obj = new Update_Vehicle();
            obj.Show();
        }

        private void btn_v_driver_Click(object sender, RoutedEventArgs e)
        {
            view_driver obj = new view_driver();
            obj.Show();

        }

        private void btn_v_cus_Click(object sender, RoutedEventArgs e)
        {
            view_customer obj = new view_customer();
            obj.Show();

        }


        private void btn_mic_on_Click(object sender, RoutedEventArgs e)
        {
            Messagebox msg = new Messagebox();
            btn_mic_on.Visibility = Visibility.Hidden;
            btn_mic_off.Visibility = Visibility.Visible;
            vc.stopVoice();
            msg.informationMsg("Voice Command Disabled");
            msg.Show();
        }

        private void btn_mic_off_Click(object sender, RoutedEventArgs e)
        {
            Messagebox msg = new Messagebox();
            try
            {
                btn_mic_on.Visibility = Visibility.Visible;
                btn_mic_off.Visibility = Visibility.Hidden;
                msg.informationMsg("Voice Command Activated");
                vc.startVoice();
                msg.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            vc.loadCommands();
        }










    }
}
