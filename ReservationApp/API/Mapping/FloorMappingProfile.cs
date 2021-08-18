using API.Entities;
using API.Models;
using AutoMapper;

namespace API.Mapping
{
    public class FloorMappingProfile : Profile
    {
        public FloorMappingProfile()
        {
            CreateMap<Floor, FloorDto>();
            CreateMap<FloorCreateDto, Floor>();
            CreateMap<FloorUpdateDto, Floor>();
        }
    }
}
