using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;

namespace API.Services
{
    public interface IFloorService
    {
        Task<IEnumerable<FloorDto>> GetAllFloors();
        Task<FloorDto> GetFloor(int id);
        Task<int> AddFloor(FloorCreateDto dto);
        Task UpdateFloor(FloorUpdateDto dto, int id);
        Task DeleteFloor(int id);
    }
}
