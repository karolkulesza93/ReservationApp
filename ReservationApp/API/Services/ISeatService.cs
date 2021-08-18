using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;

namespace API.Services
{
    public interface ISeatService
    {
        Task<IEnumerable<SeatDto>> GetAllSeats();
        Task<IEnumerable<SeatDto>> GetAllSeatsFromRoom(int number);
        Task<SeatDto> GetSeat(int id);
        Task<int> AddSeat(SeatCreateDto dto);
        Task UpdateSeat(SeatUpdateDto dto, int id);
        Task DeleteSeat(int id);
    }
}
