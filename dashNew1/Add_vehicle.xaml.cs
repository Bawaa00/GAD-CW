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
using System.Diagnostics;
using System.IO;
using System.Data;
using Microsoft.Win32;

namespace dashNew1
{
    /// <summary>
    /// Interaction logic for Add_vehicle.xaml
    /// </summary>
    public partial class Add_vehicle : Window
    {
        public Add_vehicle()
        {
            InitializeComponent();
        }

        Connect_DB db = new Connect_DB();
        string filepath;

        private String GetDestinationPath(string filename)
        {
            String appStartPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            string dir = appStartPath + "\\" + txt_lno.Text;
            // If directory does not exist, create it
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            appStartPath = String.Format(dir + "\\" + txt_lno.Text + ".jpg");
            return appStartPath;
        }

        private void btn_edit_owner_Click(object sender, RoutedEventArgs e)
        {
            Add_owner obj = new Add_owner();
            obj.Show();
        }

        private void Vehicle_Setup_Form_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = db.getData("select * from Owner");
            cbox_oid.ItemsSource = dt.DefaultView;
            cbox_oid.DisplayMemberPath = "O_ID";
            cbox_oid.SelectedValuePath = "O_ID";
            //DataTable dt2 = new DataTable();
            dt = db.getData("select * from Insurance");
            cbox_ins.ItemsSource = dt.DefaultView;
            cbox_ins.DisplayMemberPath = "I_ID";
            cbox_ins.SelectedValuePath = "I_ID";
        }

        private void btn_upload_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = false;
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            bool? result = open.ShowDialog();

            if (result == true)
            {
                filepath = open.FileName; // Stores Original Path in Textbox    
                ImageSource imgsource = new BitmapImage(new Uri(filepath)); // Just show The File In Image when we browse It
                img_vehicle.Source = imgsource;
            }
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = System.IO.Path.GetFileName(filepath);
            string destinationPath = GetDestinationPath(name);
            File.Copy(filepath, destinationPath, true);

            string query = "Insert into Vehicle values ('" + txt_lno.Text + "','" + cbox_year.Text + "','" + cbox_make.Text + "','" + txt_model.Text + "','" + cbox_category.Text + "','"+txt_cpmonth.Text+"','"+txt_cpweek.Text+"','"+txt_extra.Text+"','"+cbox_oid.Text+"','"+txt_lndate.Text+"','"+cbox_ins.Text+ "','"+txt_sdate.Text+"','"+txt_exdate.Text+"','"+destinationPath+"')";
         
                int i = db.save_update_delete(query);
                if (i == 1)
                    { 
                      Messagebox msg = new Messagebox();
                      msg.Show();
                    }
                else
                   {
                      Messagebox msg = new Messagebox();
                      msg.errorMsg("Sorry, couldn't save your data.Please try again");
                      msg.Show();
                   
                   }
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); 
            }

        }

        private void btn_view_ins_Click(object sender, RoutedEventArgs e)
        {
            View_insurnce obj = new View_insurnce();
            obj.Show();
        }

        private void btn_add_ins_Click(object sender, RoutedEventArgs e)
        {
            Owner_info obj = new Owner_info();
            obj.Show();
        }

        private void btn_home_Click(object sender, RoutedEventArgs e)
        {
            MainWindow obj = new MainWindow();
            obj.Show();
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
