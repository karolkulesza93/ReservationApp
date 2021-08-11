using System.Collections.Generic;
using API.Models;
using API.Repository;

namespace API.Services
{
    public class FloorService : IFloorService
    {
        private AppDbContext _context;

        public FloorService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<FloorDto> GetAllFloors()
        {
            throw new System.NotImplementedException();
        }

        public FloorDto GetFloor(int id)
        {
            throw new System.NotImplementedException();
        }

        public int AddFloor(FloorCreateDto floor)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateFloor(FloorUpdateDto floor, int id)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteFloor(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
