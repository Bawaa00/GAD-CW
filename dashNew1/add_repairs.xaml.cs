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
    /// Interaction logic for add_repairs.xaml
    /// </summary>
    public partial class add_repairs : Window
    {
        public add_repairs()
        {
            InitializeComponent();
        }

        Connect_DB db = new Connect_DB();

        private void cmb_type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmb_type.SelectedIndex == 0)
            {
                lbl_claim.Visibility = Visibility.Hidden;
                txt_claim.Visibility = Visibility.Hidden;
            }
            else 
            {
                lbl_claim.Visibility = Visibility.Visible;
                txt_claim.Visibility = Visibility.Visible;
            }
        }

        private void add_repair_form_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = db.getData("select * from Vehicle");
            cmb_vid.ItemsSource = dt.DefaultView;
            cmb_vid.DisplayMemberPath = "L_Plate";
            cmb_vid.SelectedValuePath = "L_Plate";
        }
    }
}
