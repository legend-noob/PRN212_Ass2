using System.Windows;
using BusinessObject;
using DataAccess.Repository;

namespace FUMiniHotelSystem.Admin
{
    public partial class AddCustomerWindow : Window
    {
        private CustomerRepository repository;
        private BusinessObject.Customer customer;
        private CustomerObject customerObject;
        DateTime dob;

        public AddCustomerWindow(BusinessObject.Customer existCustomer = null)
        {
            InitializeComponent();
            repository = new CustomerRepository();
            customer = existCustomer ?? new BusinessObject.Customer();
            customerObject = new CustomerObject();
            if (existCustomer != null)
            {

                tbEmail.Text = customer.EmailAddress;
                tbPass.Text = customer.Password;
                tbName.Text = customer.CustomerFullName;
                tbPhone.Text = customer.Telephone;
                dob = (DateTime)customer.CustomerBirthday;
            }

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string email = tbEmail.Text;
                string password = tbPass.Text;
                string name = tbName.Text;
                string phone = tbPhone.Text;
                DateTime dob = (DateTime)dpDob.SelectedDate;

                if (!customerObject.ValidateString(email))
                {
                    MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (!customerObject.ValidateString(password))
                {
                    MessageBox.Show("Please enter a valid password.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (!customerObject.ValidateString(name))
                {
                    MessageBox.Show("Please enter a valid name.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }


                customer.EmailAddress = email;
                customer.Password = password;
                customer.CustomerFullName = name;
                customer.Telephone = phone;
                customer.CustomerBirthday = dob;

                if (customer.CustomerId == 0)
                {
                    repository.Insert(customer);
                    MessageBox.Show("Customer added.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    repository.Update(customer);
                    MessageBox.Show("Customer updated.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
