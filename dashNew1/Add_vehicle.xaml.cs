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
    }
}
