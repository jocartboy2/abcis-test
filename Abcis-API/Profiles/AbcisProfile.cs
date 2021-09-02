using AutoMapper;
using Commander.Dtos;
using Commander.Models;

namespace Commander.Profiles
{
    public class AbcisProfile : Profile
    {
        public AbcisProfile()
        {
            //Source -> Target
            CreateMap<AbcisCommand, AbcisReadDto>();
            CreateMap<AbcisCreateDto, AbcisCommand>();
            CreateMap<AbcisUpdateDto, AbcisCommand>();
            CreateMap<AbcisCommand, AbcisUpdateDto>();
        }
    }
}