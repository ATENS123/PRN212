using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using BusinessObject;
using Repositories;
using Services;

namespace Service
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService()
        {
            _bookingRepository = new BookingRepository();
        }

        public IEnumerable<Booking> GetAllBookings() => _bookingRepository.GetAll();

        public Booking GetBookingById(int id) => _bookingRepository.GetById(id);

        public void AddBooking(Booking booking) => _bookingRepository.Add(booking);

        public void UpdateBooking(Booking booking) => _bookingRepository.Update(booking);

        public void DeleteBooking(int id) => _bookingRepository.Delete(id);
    }
}

