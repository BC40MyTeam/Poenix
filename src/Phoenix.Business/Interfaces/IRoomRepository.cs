using Phoenix.DataAccess.Models;
using Phoenix.DataAccess.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.Business.Interfaces
{
    public interface IRoomRepository
    {
        int CountRooms(RoomType type, RoomStatus status);
        void Delete(Room room);
        Room Get(string number);
        List<Room> GetAll(RoomType? type, RoomStatus? status, int pageNumber, int pageSize);
        Room Insert(Room room);
        Room UpdateByNumber(Room room);
    }
}
