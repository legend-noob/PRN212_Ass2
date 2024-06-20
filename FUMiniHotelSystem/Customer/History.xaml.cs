using BusinessObject;
using DataAccess.Repository;
using System.Windows;
using System.Windows.Controls;

namespace FUMiniHotelSystem.Customer;

public partial class History : Page
{
    private readonly BookingReservationRepository bookingReservationRepository = new BookingReservationRepository();
    public History()
    {
        InitializeComponent();
        LoadHistory();
    }

    private void LoadHistory()
    {
        object loggedInUserObj = Application.Current.Properties["LoggedInUser"];

        if (loggedInUserObj != null)
        {
            BusinessObject.Customer loggedInUser = loggedInUserObj as BusinessObject.Customer;

            if (loggedInUser != null)
            {
                lvBH.ItemsSource = bookingReservationRepository.GetBookingReservationByCustomerId(loggedInUser.CustomerId);
            }
        }
    }

	private void lvBH_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{

	}
}