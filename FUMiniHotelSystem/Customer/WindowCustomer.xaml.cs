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

namespace FUMiniHotelSystem.Customer
{
    /// <summary>
    /// Interaction logic for WindowCustomer.xaml
    /// </summary>
    public partial class WindowCustomer : Window
    {
        public WindowCustomer()
        {
            InitializeComponent();
        }

        private void MenuItem_Click_Profile(object sender, RoutedEventArgs e)
        {
            frCustomer.Content = new Profile();
        }

        private void MenuItem_Click_History(object sender, RoutedEventArgs e)
        {
            frCustomer.Content = new History();
        }
        private void TabItem_PreviewMouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            var loginWindow = new WindowLogin();
            loginWindow.Show();
            Close();
        }
    }
}
