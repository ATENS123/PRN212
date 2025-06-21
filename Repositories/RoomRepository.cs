using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DataAccessLayer;

namespace Repositories
{
    public class RoomRepository : IRoomRepository
    {
        public IEnumerable<Room> GetAll() => RoomDAO.GetRooms();
        public Room GetById(int id) => RoomDAO.GetById(id);
        public void Add(Room r) => RoomDAO.Add(r);
        public void Update(Room r) => RoomDAO.Update(r);
        public void Delete(int id) => RoomDAO.Delete(id);
    }


}
