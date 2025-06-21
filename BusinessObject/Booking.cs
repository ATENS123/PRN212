using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Booking
    {
        public int BookingID { get; set; }
        public int CustomerID { get; set; }
        public int RoomID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string BookingStatus { get; set; } // e.g. "Confirmed", "Cancelled", "Pending"

        // Optional: Navigation
        public virtual Customer Customer { get; set; }
        public virtual Room Room { get; set; }
    }
}
