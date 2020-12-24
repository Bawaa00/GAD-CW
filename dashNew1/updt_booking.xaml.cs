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
    /// Interaction logic for updt_booking.xaml
    /// </summary>
    public partial class updt_booking : Window
    {
        public updt_booking()
        {
            InitializeComponent();
        }
        Connect_DB db = new Connect_DB();
        private void form_up_booking_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = db.getData("select * from Booking");
            cmb_bid.ItemsSource = dt.DefaultView;
            cmb_bid.DisplayMemberPath = "BK_No";
            cmb_bid.SelectedValuePath = "BK_No";

            dt = db.getData("select * from Vehicle");
            cmb_vid.ItemsSource = dt.DefaultView;
            cmb_vid.DisplayMemberPath = "L_Plate";
            cmb_vid.SelectedValuePath = "L_Plate";

            dt = db.getData("select * from Customer");
            cmb_cid.ItemsSource = dt.DefaultView;
            cmb_cid.DisplayMemberPath = "Cus_ID";
            cmb_cid.SelectedValuePath = "Cus_ID";

            dt = db.getData("select * from Driver");
            cmb_did.ItemsSource = dt.DefaultView;
            cmb_did.DisplayMemberPath = "D_ID";
            cmb_did.SelectedValuePath = "D_ID";
        }

        private void cmb_bid_DropDownClosed(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = db.getData("exec booking_vehicle '" + cmb_bid.Text + "'");
            date_book.Text = dt.Rows[0][1].ToString();
            date_pick.Text = dt.Rows[0][2].ToString();
            date_lend.Text = dt.Rows[0][3].ToString();
            cmb_cid.Text = dt.Rows[0][4].ToString();
            txt_fname.Text = dt.Rows[0][5].ToString();
            txt_lname.Text = dt.Rows[0][6].ToString();
            cmb_vid.Text = dt.Rows[0][7].ToString();
            txt_make.Text = dt.Rows[0][8].ToString();
            txt_model.Text = dt.Rows[0][9].ToString();
            cmb_did.Text = dt.Rows[0][10].ToString();
            txt_dname.Text = dt.Rows[0][11].ToString();
        }
    }
}
