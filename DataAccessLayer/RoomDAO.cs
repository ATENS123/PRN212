using System;
using System.Collections.Generic;
using System.Linq;
using BusinessObject;

namespace DataAccessLayer
{
    public class RoomDAO
    {
        // Static in-memory list
        private static List<Room> rooms = new List<Room>();

        // Static constructor to initialize sample data once
        static RoomDAO()
        {
            for (int i = 1; i <= 20; i++)
            {
                rooms.Add(new Room(
                    i,
                    $"P{i:000}",
                    $"Phòng số {i}, tầng {((i - 1) / 5) + 1}",
                    (i % 5) switch { 0 => 4, 1 => 1, 2 => 2, 3 => 2, _ => 3 },
                    1,
                    300000 + (i * 10000),
                    (i % 5) + 1
                ));
            }
        }

        // READ - Get all rooms
        public static List<Room> GetRooms() => rooms;

        // READ - Get by ID
        public static Room GetById(int id) => rooms.FirstOrDefault(r => r.RoomID == id);

        // CREATE - Add new room
        public static void Add(Room room)
        {
            room.RoomID = rooms.Any() ? rooms.Max(r => r.RoomID) + 1 : 1;
            rooms.Add(room);
        }

        // UPDATE - Update existing room
        public static void Update(Room room)
        {
            var existing = GetById(room.RoomID);
            if (existing != null)
            {
                existing.RoomNumber = room.RoomNumber;
                existing.RoomDescription = room.RoomDescription;
                existing.RoomMaxCapacity = room.RoomMaxCapacity;
                existing.RoomStatus = room.RoomStatus;
                existing.RoomPricePerDate = room.RoomPricePerDate;
                existing.RoomTypeID = room.RoomTypeID;
            }
        }

        // DELETE - Remove room by ID
        public static void Delete(int id)
        {
            var room = GetById(id);
            if (room != null)
            {
                rooms.Remove(room);
            }
        }
    }
}
