using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DataAccessLayer;

namespace Repositories
{
    public class BookingRepository : IBookingRepository
    {
        public IEnumerable<Booking> GetAll() => BookingDAO.GetBookings();

        public Booking GetById(int id) => BookingDAO.GetById(id);

        public void Add(Booking booking) => BookingDAO.Add(booking);

        public void Update(Booking booking) => BookingDAO.Update(booking);

        public void Delete(int id) => BookingDAO.Delete(id);
    }
}
