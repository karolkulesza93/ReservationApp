using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.Exceptions;
using API.Models;
using API.Repository;
using API.Validators;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace API.Services
{
    public class FloorService : IFloorService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<FloorService> _logger;

        public FloorService(AppDbContext context, IMapper mapper, ILogger<FloorService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<FloorDto>> GetAllFloors()
        {
            _logger.LogInformation("Received GET request: all floors");
            var floors = await _context.Floors.ToListAsync();
            return _mapper.Map<List<FloorDto>>(floors);
        }

        public async Task<FloorDto> GetFloor(int id)
        {
            _logger.LogInformation($"Received GET request: floor of id={id}");
            await IdValidator.ValidateId(id);
            var floor = await _context.Floors.FindAsync(id);
            if (floor is null)
            {
                throw new EntityNotFoundException($"Floor of id={id} not found");
            }
            return _mapper.Map<FloorDto>(floor);
        }

        public async Task<int> AddFloor(FloorCreateDto dto)
        {
            _logger.LogInformation($"Received POST request: add floor");
            await FloorCreateValidator.ValidateFloorCreateDto(dto);
            var floor = _mapper.Map<Floor>(dto);
            await _context.Floors.AddAsync(floor);
            await _context.SaveChangesAsync();
            return floor.Id;
        }

        public async Task UpdateFloor(FloorUpdateDto dto, int id)
        {
            _logger.LogInformation($"Received PUT request: update floor of id={id}");
            await IdValidator.ValidateId(id);
            await FloorUpdateValidator.ValidateFloorUpdateDto(dto);
            var floor = await _context.Floors.FindAsync(id);
            if (floor is null)
            {
                throw new EntityNotFoundException($"Floor of id={id} not found");
            }
            await Task.Run(() => floor.UpdateFloor(dto));
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFloor(int id)
        {
            _logger.LogInformation($"Received DELETE request: floor of id={id}");
            await IdValidator.ValidateId(id);
            var floor = await _context.Floors.FindAsync(id);
            if (floor is null)
            {
                throw new EntityNotFoundException($"Floor of id={id} not found");
            }
            _context.Floors.Remove(floor);
            await _context.SaveChangesAsync();
        }
    }
}
