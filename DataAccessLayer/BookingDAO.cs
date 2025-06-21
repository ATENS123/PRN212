using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccessLayer
{
    public class BookingDAO
    {
        private static List<Booking> bookings = new List<Booking>();

        static BookingDAO()
        {
            // Dữ liệu mẫu ban đầu
            bookings.Add(new Booking
            {
                BookingID = 1,
                CustomerID = 2,
                RoomID = 1,
                StartDate = new DateTime(2025, 6, 21),
                EndDate = new DateTime(2025, 6, 23),
                TotalPrice = 1000000,
                BookingStatus = "Confirmed"
            });

            bookings.Add(new Booking
            {
                BookingID = 2,
                CustomerID = 3,
                RoomID = 2,
                StartDate = new DateTime(2025, 6, 24),
                EndDate = new DateTime(2025, 6, 26),
                TotalPrice = 1600000,
                BookingStatus = "Pending"
            });
        }

        public static List<Booking> GetBookings() => bookings;

        public static Booking GetById(int id) => bookings.FirstOrDefault(b => b.BookingID == id);

        public static void Add(Booking booking)
        {
            booking.BookingID = bookings.Any() ? bookings.Max(b => b.BookingID) + 1 : 1;
            bookings.Add(booking);
        }

        public static void Update(Booking booking)
        {
            var existing = GetById(booking.BookingID);
            if (existing != null)
            {
                existing.CustomerID = booking.CustomerID;
                existing.RoomID = booking.RoomID;
                existing.StartDate = booking.StartDate;
                existing.EndDate = booking.EndDate;
                existing.TotalPrice = booking.TotalPrice;
                existing.BookingStatus = booking.BookingStatus;
            }
        }

        public static void Delete(int id)
        {
            var booking = GetById(id);
            if (booking != null)
            {
                bookings.Remove(booking);
            }
        }
    }
}
