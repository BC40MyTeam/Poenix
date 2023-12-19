using Microsoft.EntityFrameworkCore;
using Phoenix.Business.Interfaces;
using Phoenix.DataAccess.Models;
using Phoenix.DataAccess.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.Business.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly PhoenixContext _context;

        public RoomRepository(PhoenixContext context)
        {
            _context = context;
        }

        //public bool IsRoomReserved(string number)
        //{
        //    var room = _context.Reservations.FirstOrDefault(r => r.RoomNumber.Equals(number));
        //    if ()
        //}

        public List<Room> GetAll(RoomType? type, RoomStatus? status, int pageNumber, int pageSize)
        {

            var query = from room in _context.Rooms 
                        join r in _context.Reservations on room.Number equals r.RoomNumber
                        where (type == null || room.RoomType == type)    
                        //&& (status == null || r.) //check room availability here
                        select room;
            return query
                .Skip((pageNumber-1)*pageSize)
                .Take(pageSize)
                .ToList();
        }

        public int CountRooms(RoomType type, RoomStatus status)
        {
            var query = from room in _context.Rooms
                        join r in _context.Reservations on room.Number equals r.RoomNumber
                        where (type == null || room.RoomType == type)
                        //&& (status == null || r.) //check room availability here
                        select room;
            return query.Count();
        }

        public Room Get(string number)
        {
            return _context.Rooms.FirstOrDefault(r => r.Number.Equals(number))
                ?? throw new ArgumentNullException("No room found for " + number);
        }

        public Room Insert(Room room)
        {
            _context.Rooms.Add(room);
            _context.SaveChanges();
            return room;
        }

        public Room UpdateByNumber(Room room)
        {
            _context.Rooms.Update(room);
            _context.SaveChanges();
            return room;
        }

        public void Delete(Room room)
        {
            _context.Rooms.Remove(room);
            _context.SaveChanges();
        }
    }
}
