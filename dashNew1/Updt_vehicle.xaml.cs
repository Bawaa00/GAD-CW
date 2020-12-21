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
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;

namespace dashNew1
{
    /// <summary>
    /// Interaction logic for Updt_vehicle.xaml
    /// </summary>
    public partial class Updt_vehicle : Window
    {
        public Updt_vehicle()
        {
            InitializeComponent();
        }
        Connect_DB db = new Connect_DB();
        string path;

        private String GetDestinationPath(string filename)
        {
            String appStartPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            string dir = appStartPath + "\\" + cbox_lplate.Text;
            // If directory does not exist, create it
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            appStartPath = String.Format(dir + "\\" + cbox_lplate.Text + ".jpg");
            return appStartPath;
        }

        private void form_vehicle_update_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = db.getData("select * from Vehicle");
            cbox_lplate.ItemsSource = dt.DefaultView;
            cbox_lplate.DisplayMemberPath = "L_Plate";
            cbox_lplate.SelectedValuePath = "L_Plate";
        }

        private void btn_upload_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = false;
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            bool? result = open.ShowDialog();

            if (result == true)
            {
                path = open.FileName; // Stores Original Path in Textbox    
                ImageSource imgsource = new BitmapImage(new Uri(path)); // Just show The File In Image when we browse It
                img_vehicle.Source = imgsource;
            }
        }

        private void cbox_lplate_DropDownClosed(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = db.getData("select * from Vehicle where L_Plate='" + cbox_lplate.Text.ToString() + "'");
            cbox_year.Text = dt.Rows[0][1].ToString();
            cbox_make.Text = dt.Rows[0][2].ToString();
            txt_model.Text = dt.Rows[0][3].ToString();
            cbox_category.Text = dt.Rows[0][4].ToString();
            txt_cpweek.Text = dt.Rows[0][6].ToString();
            txt_cpmonth.Text = dt.Rows[0][5].ToString();
            txt_extra.Text = dt.Rows[0][7].ToString();
            cbox_oid.Text = dt.Rows[0][8].ToString();
            txt_lndate.Text = dt.Rows[0][9].ToString();
            cbox_ins.Text = dt.Rows[0][10].ToString();
            txt_sdate.Text = dt.Rows[0][11].ToString();
            txt_exdate.Text = dt.Rows[0][12].ToString();
            path = dt.Rows[0][13].ToString();
            ImageSource imgsource = new BitmapImage(new Uri(path)); // Just show The File In Image when we browse It
            img_vehicle.Source = imgsource;
        }
    }
}
