using System.Collections.Generic;
using System.Linq;
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
    public class RoomService : IRoomService
    {
        private AppDbContext _context;
        private IMapper _mapper;
        private readonly ILogger<RoomService> _logger;

        public RoomService(AppDbContext context, IMapper mapper, ILogger<RoomService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<RoomDto>> GetAllRooms()
        {
            _logger.LogInformation("Received GET request: all rooms");
            var rooms = await _context.Rooms.ToListAsync();
            return _mapper.Map<List<RoomDto>>(rooms);
        }

        public async Task<IEnumerable<RoomDto>> GetAllRoomsOnFloor(int number)
        {
            _logger.LogInformation($"Received GET request: all rooms on floor of number={number}");
            var rooms = await _context.Rooms.Include(r => r.Floor).Where(r => r.Floor.Number == number).ToListAsync();
            return _mapper.Map<List<RoomDto>>(rooms);
        }

        public async Task<RoomDto> GetRoom(int id)
        {
            _logger.LogInformation($"Received GET request: room of id={id}");
            await IdValidator.ValidateId(id);
            var room = await _context.Rooms.FindAsync(id);
            if (room is null)
            {
                throw new EntityNotFoundException($"Room of id={id} not found");
            }
            return _mapper.Map<RoomDto>(room);
        }

        public async Task<int> AddRoom(RoomCreateDto dto)
        {
            _logger.LogInformation($"Received POST request: add room");
            await RoomCreateValidator.ValidateRoomCreateDto(dto);
            var room = _mapper.Map<Room>(dto);
            await _context.Rooms.AddAsync(room);
            await _context.SaveChangesAsync();
            return room.Id;
        }

        public async Task UpdateRoom(RoomUpdateDto dto, int id)
        {
            _logger.LogInformation($"Received PUT request: update room of id={id}");
            await IdValidator.ValidateId(id);
            await RoomUpdateValidator.ValidateRoomUpdateDto(dto);
            var room = await _context.Rooms.FindAsync(id);
            if (room is null)
            {
                throw new EntityNotFoundException($"Room of id={id} not found");
            }
            await new Task(() => room.UpdateRoom(dto));
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoom(int id)
        {
            _logger.LogInformation($"Received DELETE request: room of id={id}");
            await IdValidator.ValidateId(id);
            var room = await _context.Rooms.FindAsync(id);
            if (room is null)
            {
                throw new EntityNotFoundException($"Room of id={id} not found");
            }
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
        }
    }
}
