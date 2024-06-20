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
    /// Interaction logic for ReportStatistic.xaml
    /// </summary>
    public partial class ReportStatistic : Page
    {
        private readonly BookingReservationRepository bookingReservationRepository;
        public ReportStatistic()
        {
            InitializeComponent();
            bookingReservationRepository = new BookingReservationRepository();
            LoadBookingReservation();
        }
        private void LoadBookingReservation()
        {
            var br = bookingReservationRepository.GetBookingReservations();
            lvBr.ItemsSource = br;
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DateTime? selectedStartDate = dpStartDate.SelectedDate;
            DateTime? selectedEndDate = dpEndDate.SelectedDate;

            if (selectedStartDate == null && selectedEndDate == null)
            {
                var listBooking = bookingReservationRepository.GetBookingReservations();
                lvBr.ItemsSource = listBooking;
            }
            else
            {
                DateTime startDate = selectedStartDate ?? DateTime.Now;
                DateTime endDate = selectedEndDate?.Date.AddDays(1) ?? DateTime.Now.AddDays(1);
                var filteredBookingReservation = bookingReservationRepository.GetBookingReservations(startDate, endDate);
                lvBr.ItemsSource = filteredBookingReservation;
            }
        }

    }
}
