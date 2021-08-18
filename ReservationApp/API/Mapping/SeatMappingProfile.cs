using API.Entities;
using API.Models;
using AutoMapper;

namespace API.Mapping
{
    public class SeatMappingProfile : Profile
    {
        public SeatMappingProfile()
        {
            CreateMap<Seat, SeatDto>();
            CreateMap<SeatCreateDto, Seat>();
            CreateMap<SeatUpdateDto, Seat>();
        }
    }
}
