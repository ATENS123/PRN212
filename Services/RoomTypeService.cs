using System.Collections.Generic;
using BusinessObject;
using Repositories;
using Services;

namespace Service
{
    public class RoomTypeService : IRoomTypeService
    {
        private readonly IRoomTypeRepository _roomTypeRepository;

        public RoomTypeService()
        {
            _roomTypeRepository = new RoomTypeRepository();
        }

        public IEnumerable<RoomType> GetAllRoomTypes() => _roomTypeRepository.GetAll();

        public RoomType GetRoomTypeById(int id) => _roomTypeRepository.GetById(id);
    }
}
