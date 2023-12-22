using Phoenix.Business.Interfaces;
using Phoenix.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.Business.Repositories;
public class RoomServiceRepository : IRoomServiceRepository
{
    private readonly PhoenixContext _context;

    public RoomServiceRepository(PhoenixContext context)
    {
        _context = context;
    }

    public List<RoomService> GetAllEmployee()
    {
        var query = from room in _context.RoomServices
                    select new RoomService
                    {
                        EmployeeNumber = room.EmployeeNumber,
                        FirstName = room.FirstName,
                        MiddleName = room.MiddleName,
                        LastName = room.LastName,
                        OutsourcingCompany = room.OutsourcingCompany
                    };

        return query
               .ToList();     
    }

    public RoomService InsertEmployee(RoomService room)
    {
        _context.RoomServices.Add(room);
        _context.SaveChanges();
        return room;
    }

}

