using Phoenix.DataAccess.Models;

namespace Phoenix.Business;
public interface IReservationRepository
{
    public List<Reservation> GetAllReservation(string? RoomNumber, string? GuesUsername, DateTime? DateBefore);
}
