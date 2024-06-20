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

namespace FUMiniHotelSystem.Admin
{
    public partial class WindowAdmin : Window
    {
        public WindowAdmin()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            frAdmin.Content = new CustomerManager();
        }

        private void btnRoom_Click(object sender, RoutedEventArgs e)
        {
            frAdmin.Content = new RoomInfoManager();
        }
        private void TabItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            frAdmin.Content = new ReportStatistic();
        }

        private void TabItem_PreviewMouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            var loginWindow = new WindowLogin();
            loginWindow.Show();
            Close();
        }
    }
}
