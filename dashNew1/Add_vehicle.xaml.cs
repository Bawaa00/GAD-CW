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
using System.Text.RegularExpressions;

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

            txt_lno.Clear();
            txt_model.Clear();
            txt_cpmonth.Clear();
            txt_cpweek.Clear();
            txt_extra.Clear();
            txt_lndate.Text = "";
            txt_sdate.Text = "";
            txt_exdate.Text = "";
            cbox_category.Text = "";
            cbox_year.SelectedIndex = -1;
            cbox_make.SelectedIndex = -1;
        }

        private void btn_upload_Click(object sender, RoutedEventArgs e)
        {
            try
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
            catch(Exception ex)
            {
                Messagebox msg = new Messagebox();
                msg.errorMsg("Oops soomething went worng. " + ex.Message);
                msg.Show();
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
                if (string.IsNullOrEmpty(error_msg.Text))
                {
                    int i = db.save_update_delete(query);
                    if (i == 2)
                    {
                        Messagebox msg = new Messagebox();
                        Vehicle_Setup_Form_Loaded(this, null);
                        msg.Show();
                    }
                    else
                    {
                        Messagebox msg = new Messagebox();
                        msg.errorMsg("Sorry, couldn't save your data.Please try again. ");
                        msg.Show();

                    }
                }
                else
                {
                    Messagebox msg = new Messagebox();
                    msg.errorMsg("Please fill out the form properly");
                    msg.Show();
                }
            }
            catch (ArgumentNullException)
            {
                Messagebox msg = new Messagebox();
                msg.errorMsg("Please upload a photo");
                msg.Show();
            }
            catch (System.Data.SqlClient.SqlException)
            {
                Messagebox msg = new Messagebox();
                msg.errorMsg("Please fill the form correctly. Database Error");
                msg.Show();
            }
            catch (Exception ex)
            {
                Messagebox msg = new Messagebox();
                msg.errorMsg("Oops something went worng. " + ex.Message);
                msg.Show();
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
            this.Close();
            obj.Show();
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_cls_Click(object sender, RoutedEventArgs e)
        {
            Vehicle_Setup_Form_Loaded(this, null);
        }

        private void txt_lno_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_lno.Text.Length == 0)
            { error_msg.Text = "Please Enter license Number "; }
            else
            {
                error_msg.Text = "";
            }
        }

        private void txt_model_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_model.Text.Length == 0)
                error_msg.Text = "Please Enter Model ";
            else if (txt_model.Text.Any(char.IsSymbol))
                error_msg.Text = "Model cannot contain symbols";
            else
                error_msg.Text = "";
        }

        private void txt_cpweek_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_cpweek.Text.Length == 0)
                error_msg.Text = "Please Enter Cost per week ";
           /* else if (txt_cpweek.Text.Any(char.IsLetter))
                error_msg.Text = "Cost per week cannot have letters";
            else if (txt_cpweek.Text.Any(char.IsSymbol))
                error_msg.Text = "Cost per week cannot contain symbols";
            else if (txt_cpweek.Text.Any(char.IsWhiteSpace))
                error_msg.Text = "Cost per week cannot contain spaces";*/
            else if (!Regex.IsMatch(txt_cpweek.Text, "^[0-9]*$"))
                error_msg.Text = "Please enter numbers only";
            else
                error_msg.Text = "";
        }

        private void txt_cpmonth_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_cpmonth.Text.Length == 0)
                error_msg.Text = "Please Enter Cost per Month ";
            else if (!Regex.IsMatch(txt_cpmonth.Text, "^[0-9]*$"))
                error_msg.Text = "Please enter numbers only";
            else
                error_msg.Text = "";
        }

        private void txt_extra_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_cpweek.Text.Length == 0)
                error_msg.Text = "Please Enter Extra Cost per Milege ";
            else if (!Regex.IsMatch(txt_cpweek.Text, "^[0-9]*$"))
                error_msg.Text = "Please enter numbers only";
            else
                error_msg.Text = "";
        }

        private void cbox_year_DropDownClosed(object sender, EventArgs e)
        {
            if (cbox_year.SelectedItem == null)
            {
                error_msg.Text = "Please Select Year";
            }
            else { error_msg.Text = ""; }
        }

        private void cbox_make_DropDownClosed(object sender, EventArgs e)
        {
            if (cbox_make.SelectedItem == null)
            {
                error_msg.Text = "Please Select Make";
            }
            else { error_msg.Text = ""; }
        }

        private void cbox_category_DropDownClosed(object sender, EventArgs e)
        {
            if (cbox_category.SelectedItem == null)
            {
                error_msg.Text = "Please Select Catagory";
            }
            else { error_msg.Text = ""; }
        }

        private void cbox_oid_DropDownClosed(object sender, EventArgs e)
        {
            if (cbox_oid.SelectedItem == null)
            {
                error_msg.Text = "Please Select Owner ID";
            }
            else { error_msg.Text = ""; }
        }

        private void cbox_ins_DropDownClosed(object sender, EventArgs e)
        {
            if (cbox_ins.SelectedItem == null)
            {
                error_msg.Text = "Please Select Insurance";
            }
            else { error_msg.Text = ""; }
        }

    }
}
