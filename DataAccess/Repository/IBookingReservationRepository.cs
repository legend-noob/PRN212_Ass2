using BusinessObject;
using DataAccess.DAO;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccess.DAO.BookingReservationDAO;

namespace DataAccess.Repository
{
    public interface IBookingReservationRepository
    {
        public IEnumerable<BookingReservationWithCustomerName> GetBookingReservationByCustomerId(int customerId);
        public IEnumerable<BookingReservationDTO> GetBookingReservations();

        public IEnumerable<BookingReservationDTO> GetBookingReservations(DateTime startDate, DateTime endDate);

    }
}
