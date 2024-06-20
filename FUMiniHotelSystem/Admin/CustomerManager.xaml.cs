using BusinessObject;
using DataAccess.Repository;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FUMiniHotelSystem.Admin
{
    /// <summary>
    /// Interaction logic for CustomerManager.xaml
    /// </summary>
    public partial class CustomerManager : Page
    {
        private CustomerRepository customerRepository = new CustomerRepository();
        public CustomerManager()
        {
            InitializeComponent();
            loadCustomer();
        }

        private void loadCustomer()
        {
            var c = customerRepository.GetMembers();
            lvCus.ItemsSource = c;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddCustomerWindow addCustomerWindow = new AddCustomerWindow();
            addCustomerWindow.ShowDialog();
            loadCustomer();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (lvCus.SelectedItem != null)
            {
                BusinessObject.Customer customer = (BusinessObject.Customer)lvCus.SelectedItem;
                AddCustomerWindow addCustomerWindow = new AddCustomerWindow(customer);
                addCustomerWindow.ShowDialog();
                loadCustomer();
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
            var m = MessageBox.Show("Are you sure you want to delete this customer?", "Delete customer", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (m == MessageBoxResult.Yes)
            {
                if (lvCus.SelectedItem != null)
                {
                    customerRepository.Delete((BusinessObject.Customer)lvCus.SelectedItem);
                    loadCustomer();
                }
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var searchKey = tbSearch.Text;
            if (string.IsNullOrWhiteSpace(searchKey))
            {
                loadCustomer();
            }
            else
            {
                var c = customerRepository.GetUserByName(searchKey);
                lvCus.ItemsSource = c;
            }
        }
    }
}
