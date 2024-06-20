using System;
using System.Collections.Generic;
using System.Globalization;
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
using DataAccess.Repository;

namespace FUMiniHotelSystem.Customer
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {
        private readonly CustomerRepository _customerRepository = new CustomerRepository();

        public Profile()
        {
            InitializeComponent();
            LoadProfile();
        }
        private void LoadProfile()
        {
            object loggedInUserObj = Application.Current.Properties["LoggedInUser"];
            DateTime parsedDate;
            if (loggedInUserObj != null)
            {
                BusinessObject.Customer loggedInUser = (BusinessObject.Customer)loggedInUserObj;

                if (loggedInUser != null)
                {
                    tbEmail.Text = loggedInUser.EmailAddress;
                    tbName.Text = loggedInUser.CustomerFullName;
                    tbPass.Text = loggedInUser.Password;
                    tbPhone.Text = loggedInUser.Telephone;
                }
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            object loggedInUserObj = Application.Current.Properties["LoggedInUser"];


            if (loggedInUserObj != null)
            {
                BusinessObject.Customer loggedInUser = (BusinessObject.Customer)loggedInUserObj;

                if (loggedInUser != null)
                {
                    loggedInUser.EmailAddress = tbEmail.Text;
                    loggedInUser.CustomerFullName = tbName.Text;
                    loggedInUser.Password = tbPass.Text;
                    loggedInUser.Telephone = tbPhone.Text;

                    try
                    {
                        _customerRepository.Update(loggedInUser);
                        MessageBox.Show("Profile updated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while saving the profile: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
		private void Cancel_Click(object sender, RoutedEventArgs e)
		{
			if (this.NavigationService != null)
			{
				this.NavigationService.GoBack();
			}
			else
			{
				MessageBox.Show("No navigation service available to navigate back.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
	}
}
