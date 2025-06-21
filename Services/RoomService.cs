using System.Collections.Generic;
using BusinessObject;
using Repositories;
using Services;

namespace Service
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService()
        {
            _roomRepository = new RoomRepository();
        }

        public IEnumerable<Room> GetAllRooms() => _roomRepository.GetAll();

        public Room GetRoomById(int id) => _roomRepository.GetById(id);

        public void AddRoom(Room room) => _roomRepository.Add(room);

        public void UpdateRoom(Room room) => _roomRepository.Update(room);

        public void DeleteRoom(int id) => _roomRepository.Delete(id);
    }
}
