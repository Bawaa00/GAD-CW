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
using System.Windows.Shapes;
using System.Data;

namespace dashNew1
{
    /// <summary>
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : Window
    {
        //Connect_DB db = new Connect_DB();
        //Hashcode hc = new Hashcode();

        public login()
        {
            InitializeComponent();
        }

        private void btn_log_Click(object sender, RoutedEventArgs e)
        {
            LoadingScreen ls = new LoadingScreen();
            ls.Show();
            this.Close();
            /*DataTable dt = new DataTable();
            dt = db.getData("Select * from User_login where U_name = '" + txt_uname.Text + "' and U_pass='" + hc.PassHash(pass_box.Password) + "' ");
            if (dt.Rows.Count == 1)
            {
                LoadingScreen ls = new LoadingScreen();
                this.Hide();
                ls.Show();
            }
            else
            {
                txt_error.Text = "Check Username and Password";
            }*/
        }
    }
}
