using CarRental.AppConfig;
using Microsoft.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarRental.Pages
{
    /// <summary>
    /// Interaction logic for Workreg.xaml
    /// </summary>
    public partial class Workreg : Page
    {
        public Workreg()
        {
            InitializeComponent();
            string[] gen = { "Male", "female" };
            cmbgender.ItemsSource = gen;
            string[] desig = {"Permanent","Contract" };
            cmbdes.ItemsSource = desig;
            string[] rol = { "Admin", "Worker" };
            cmbrole.ItemsSource = rol;

            string connection = Settings1.Default.SQLConnect;
            using (SqlConnection sqlConnection = new SqlConnection(connection))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select EMP_NAME,EMP_EMAIL,DESIGNATION,EMP_LOCATION from EMPLOYEE ", sqlConnection);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "emp");
                listemp.ItemsSource=null;
                listemp.ItemsSource = dataSet.Tables["emp"].DefaultView;
                sqlConnection.Close();
            }

        }

        private void btnreg_Click(object sender, RoutedEventArgs e)
        {
            
                string connection = Settings1.Default.SQLConnect;
                string Gender = cmbgender.SelectedItem.ToString() ;
                string Designation =cmbdes.SelectedItem.ToString() ;
                string role = cmbrole.SelectedItem.ToString();
                BL.Workerreg workreg = new BL.Workerreg();
                int output = workreg.Toregister(connection, txtname.Text, createpw.Text, txtage.Text, Gender, txtemail.Text, txtphn.Text, Designation, txtlocation.Text, role, txtdjoin.SelectedDate.ToString(), txtdend.SelectedDate.ToString(),txtwrking.Text,txtsalary.Text);
                if (output == 1)
                {
                    MessageBox.Show("Registered Successfully", "Car Rental");
                }
                txtage.Clear();
                txtemail.Clear();
                txtlocation.Clear();
                txtname.Clear();
                txtphn.Clear()  ;
                txtsalary.Clear();
                txtwrking.Clear();
              
                
        }
           
        private void btnsearch_Click(object sender, RoutedEventArgs e)
        {
            string connection = Settings1.Default.SQLConnect;
            using (SqlConnection sqlConnection = new SqlConnection(connection))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"exec USP_SEARCH '{txtsearch.Text}'", sqlConnection);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "emp");
                listemp.ItemsSource = null;
                listemp.ItemsSource = dataSet.Tables["emp"].DefaultView;
                sqlConnection.Close();
            }
        }
    }
}
