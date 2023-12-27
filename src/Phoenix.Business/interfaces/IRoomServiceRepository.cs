using Phoenix.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.Business.Interfaces;
public interface IRoomServiceRepository
{
    public List<RoomService> GetAllEmployee();
    RoomService InsertEmployee(RoomService roomService);
    RoomService GetByNumber(string employeeNumber);
    RoomService UpdatedEmployee(RoomService roomService);
}

