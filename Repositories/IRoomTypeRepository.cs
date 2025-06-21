using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace Repositories
{
    public interface IRoomTypeRepository
    {
        IEnumerable<RoomType> GetAll();
        RoomType GetById(int id);
    }
}
