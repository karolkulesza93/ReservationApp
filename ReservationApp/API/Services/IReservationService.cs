using System.Collections.Generic;
using API.Models;

namespace API.Services
{
    public interface IReservationService
    {
        IEnumerable<ReservationDto> GetAllReservations();
        ReservationDto GetReservation(int id);
        int AddReservation(ReservationCreateDto dto);
        bool UpdateReservation(ReservationUpdateDto dto, int id);
        bool DeleteReservation(int id);
    }
}
