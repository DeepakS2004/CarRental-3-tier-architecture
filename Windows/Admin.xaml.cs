using CarRental.Pages;
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

namespace CarRental.Windows
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        Workreg Workreg;
        public Admin()
        {
            InitializeComponent();
            Workreg = new Workreg();
        }

        private void btnreg_Click(object sender, RoutedEventArgs e)
        {
            mainframe.Content = Workreg;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
