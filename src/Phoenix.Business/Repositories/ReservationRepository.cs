using Microsoft.Identity.Client;
using Phoenix.DataAccess.Models;

namespace Phoenix.Business;

public class ReservationRepository:IReservationRepository
{
    private readonly PhoenixContext _context;

    public ReservationRepository(PhoenixContext context){
        _context = context;
    }

    public List<Reservation> GetAllReservation(string? RoomNumber, string? GuesUsername, DateTime? DateBefore){
        var query = from reservation in _context.Reservations
                    where (reservation.RoomNumber == null || 
                    (reservation.RoomNumber != null && reservation.RoomNumber.Contains(RoomNumber))) &&
                    (reservation.GuestUsername == null || 
                    (reservation.GuestUsername != null && reservation.GuestUsername.Contains(GuesUsername))) &&
                    (reservation.BookDate == null || reservation.BookDate < DateBefore)
                    select reservation;
        return query.ToList();
    }
}
