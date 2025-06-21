using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DataAccessLayer;

namespace Repositories
{
    public class RoomTypeRepository : IRoomTypeRepository
    {
        private List<RoomType> roomTypes => RoomTypeDAO.GetRoomTypes();

        public IEnumerable<RoomType> GetAll() => roomTypes;

        public RoomType GetById(int id) => roomTypes.FirstOrDefault(rt => rt.RoomTypeID == id);
    }
}
