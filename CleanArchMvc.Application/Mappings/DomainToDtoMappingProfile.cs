using AutoMapper;
using CleanArchMvc.Application.Clubs.Create;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Application.Mappings
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Club, ClubCreateCommand>().ReverseMap();
            CreateMap<Club, ClubDto>().ReverseMap();

            CreateMap<Player, PlayerDto>()
                .ForMember(dest => dest.DateBirth, opt => opt.MapFrom(x => DateOnly.FromDateTime(x.DateBirth)))
                .ReverseMap();
            
            CreateMap<Trophy, TrophyDto>().ReverseMap();
        }
    }
}
