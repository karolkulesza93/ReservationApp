using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;

namespace API.Services
{
    public interface IRoomService
    {
        Task<IEnumerable<RoomDto>> GetAllRooms();
        Task<IEnumerable<RoomDto>> GetAllRoomsOnFloor(int number);
        Task<RoomDto> GetRoom(int id);
        Task<int> AddRoom(RoomCreateDto dto);
        Task UpdateRoom(RoomUpdateDto dto, int id);
        Task DeleteRoom(int id);
    }
}
