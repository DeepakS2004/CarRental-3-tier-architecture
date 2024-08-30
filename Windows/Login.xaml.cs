using System;
using System.Collections.Generic;
using System.Data;
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
using CarRental.AppConfig;
using CarRental.BL;
using Microsoft.Data.SqlClient;


namespace CarRental.Windows
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        
      
        public Login()
        {
            InitializeComponent();

        }

        private void btnadmin_Click(object sender, RoutedEventArgs e)
        {
            string connection = Settings1.Default.SQLConnect;
            Adminlogincs adminlogincs = new Adminlogincs();
            string result = adminlogincs.GetRole(txtusername.Text, pwbox.Password, connection);

            if (result == "ADMIN")
            {
                Admin admin = new Admin();
                admin.Show();
            }
           else if(result =="Worker")
           {
                Worker worker = new Worker();
                worker.Show();
           }       
            else
            {
                MessageBox.Show("Invalid User", "Car Rental", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            txtusername.Clear();
            pwbox.Clear();         
        }

       
    }
}
