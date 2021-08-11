using System.Collections.Generic;
using API.Models;

namespace API.Services
{
    public interface IFloorService
    {
        IEnumerable<FloorDto> GetAllFloors();
        FloorDto GetFloor(int id);
        int AddFloor(FloorCreateDto floor);
        bool UpdateFloor(FloorUpdateDto floor, int id);
        bool DeleteFloor(int id);
    }
}
