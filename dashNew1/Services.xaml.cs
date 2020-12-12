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
using System.Text.RegularExpressions;

namespace dashNew1
{
    /// <summary>
    /// Interaction logic for Services.xaml
    /// </summary>
    public partial class Services : Window
    {
        Connect_DB db = new Connect_DB();

        public Services()
        {
            InitializeComponent();
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            string query = "Insert into Service values ('" + cmb_vid.Text + "','" + txt_Sid.Text + "','" + txt_Sdetails.Text + "','" + txt_milge.Text + "','" + txt_nxt.Text + "')";

            int i = db.save_update_delete(query);
            if (i == 1)
                MessageBox.Show("Data save Successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("Data cannot save", "error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void add_service_form_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = db.getData("select * from Vehicle");
            cmb_vid.ItemsSource = dt.DefaultView;
            cmb_vid.DisplayMemberPath = "L_Plate";
            cmb_vid.SelectedValuePath = "L_Plate";

            dt = db.getData("Select max(S_ID) from Service");
            string id = dt.Rows[0][0].ToString();
            var prefix = Regex.Match(id, "^\\D+").Value;
            var number = Regex.Replace(id, "^\\D+", "");
            var i = int.Parse(number) + 1;
            var newString = prefix + i.ToString(new string('0', number.Length));
            txt_Sid.Text = newString;
        }
    }
}
