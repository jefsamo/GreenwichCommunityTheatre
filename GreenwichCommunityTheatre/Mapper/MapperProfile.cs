using AutoMapper;
using GreenwichCommunityTheatre.Application.DTOs.Auth;
using GreenwichCommunityTheatre.Application.DTOs.Play;
using GreenwichCommunityTheatre.Domain.Entities;

namespace GreenwichCommunityTheatre.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, RegisterDto>().ReverseMap();
            CreateMap<User, RegisterResponseDto>().ReverseMap();
            CreateMap<Play, CreatePlayDto>().ReverseMap();
            CreateMap<Play, PlayResponseDto>().ReverseMap();
            CreateMap<Play, UpdatePlayDto>().ReverseMap();
        }
    }
}
