using AutoMapper;
using GreenwichCommunityTheatre.Application.DTOs.Auth;
using GreenwichCommunityTheatre.Domain.Entities;

namespace GreenwichCommunityTheatre.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, RegisterDto>().ReverseMap();
            CreateMap<User, RegisterResponseDto>().ReverseMap();
        }
    }
}
