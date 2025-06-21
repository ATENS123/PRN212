using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Room
    {
        public Room(int id, string number, string description, int capacity, int status, decimal price, int roomTypeId)
        {
            RoomID = id;
            RoomNumber = number;
            RoomDescription = description;
            RoomMaxCapacity = capacity;
            RoomStatus = status;
            RoomPricePerDate = price;
            RoomTypeID = roomTypeId;
        }

        public int RoomID { get; set; }
        public string RoomNumber { get; set; }
        public string RoomDescription { get; set; }
        public int? RoomMaxCapacity { get; set; }
        public int? RoomStatus { get; set; }
        public decimal? RoomPricePerDate { get; set; }
        public int? RoomTypeID { get; set; }

        public virtual RoomType RoomType { get; set; } // Navigation property
    }

}
