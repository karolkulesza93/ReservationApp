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
    public class SeatService : ISeatService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<SeatService> _logger;

        public SeatService(AppDbContext context, IMapper mapper, ILogger<SeatService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<SeatDto>> GetAllSeats()
        {
            _logger.LogInformation("Received GET request: all seats");
            var seats = await _context.Seats.ToListAsync();
            return _mapper.Map<List<SeatDto>>(seats);
        }

        public async Task<IEnumerable<SeatDto>> GetAllSeatsFromRoom(int number)
        {
            _logger.LogInformation($"Received GET request: all seats from room of number={number}");
            var seats = await _context.Seats.Include(s => s.Room).Where(s => s.Room.Number == number).ToListAsync();
            return _mapper.Map<List<SeatDto>>(seats);
        }

        public async Task<SeatDto> GetSeat(int id)
        {
            _logger.LogInformation($"Received GET request: seat of id={id}");
            await IdValidator.ValidateId(id);
            var seat = await _context.Seats.FindAsync(id);
            if (seat is null)
            {
                throw new EntityNotFoundException($"Seat of id={id} not found");
            }
            return _mapper.Map<SeatDto>(seat);
        }

        public async Task<int> AddSeat(SeatCreateDto dto)
        {
            _logger.LogInformation($"Received POST request: add seat");
            await SeatCreateValidator.ValidateSeatCreateDto(dto);
            var seat = _mapper.Map<Seat>(dto);
            await _context.Seats.AddAsync(seat);
            await _context.SaveChangesAsync();
            return seat.Id;
        }

        public async Task UpdateSeat(SeatUpdateDto dto, int id)
        {
            _logger.LogInformation($"Received PUT request: update seat of id={id}");
            await IdValidator.ValidateId(id);
            await SeatUpdateValidator.ValidateSeatUpdateDto(dto);
            var seat = await _context.Seats.FindAsync(id);
            if (seat is null)
            {
                throw new EntityNotFoundException($"Seat of id={id} not found");
            }
            await new Task(() => seat.UpdateSeat(dto));
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSeat(int id)
        {
            _logger.LogInformation($"Received DELETE request: seat of id={id}");
            await IdValidator.ValidateId(id);
            var seat = await _context.Seats.FindAsync(id);
            if (seat is null)
            {
                throw new EntityNotFoundException($"Seat of id={id} not found");
            }
            _context.Seats.Remove(seat);
            await _context.SaveChangesAsync();
        }
    }
}
