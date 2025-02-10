using AutoMapper;
using GreenwichCommunityTheatre.Application.DTOs.Auth;
using GreenwichCommunityTheatre.Application.DTOs.Play;
using GreenwichCommunityTheatre.Application.DTOs.Reservation;
using GreenwichCommunityTheatre.Application.DTOs.Seat;
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

            CreateMap<Seat, CreateSeatDto>().ReverseMap();
            CreateMap<Seat, SeatResponseDto>().ReverseMap();
            CreateMap<Seat, UpdateSeatDto>().ReverseMap();

            CreateMap<Reservation, CreateReservationDto>().ReverseMap();
            CreateMap<Reservation, ReservationResponseDto>().ReverseMap();

            CreateMap<Ticket, TicketResponseDto>().ReverseMap();
            CreateMap<Ticket, TicketDto>().ReverseMap();
        }
    }
}
