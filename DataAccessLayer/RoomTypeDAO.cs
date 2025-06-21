using System;
using System.Collections.Generic;
using System.Linq;
using BusinessObject;

namespace DataAccessLayer
{
    public class RoomTypeDAO
    {
        // Danh sách in-memory static
        private static List<RoomType> roomTypes = new List<RoomType>
        {
            new RoomType(1, "Single", "1 người", "Phòng nhỏ"),
            new RoomType(2, "Double", "2 người", "Phòng tiêu chuẩn"),
            new RoomType(3, "Deluxe", "Sang trọng", "Phòng cao cấp"),
            new RoomType(4, "Family", "4 người", "Phòng gia đình"),
            new RoomType(5, "Suite", "VIP", "Phòng thượng hạng")
        };

        public static List<RoomType> GetRoomTypes() => roomTypes;

        public static RoomType GetById(int id) =>
            roomTypes.FirstOrDefault(rt => rt.RoomTypeID == id);

        public static void Add(RoomType roomType)
        {
            roomType.RoomTypeID = roomTypes.Any() ? roomTypes.Max(rt => rt.RoomTypeID) + 1 : 1;
            roomTypes.Add(roomType);
        }

        public static void Update(RoomType roomType)
        {
            var existing = GetById(roomType.RoomTypeID);
            if (existing != null)
            {
                existing.RoomTypeName = roomType.RoomTypeName;
                existing.TypeDescription = roomType.TypeDescription;
                existing.TypeNote = roomType.TypeNote;
            }
        }

        public static void Delete(int id)
        {
            var existing = GetById(id);
            if (existing != null)
            {
                roomTypes.Remove(existing);
            }
        }
    }
}
