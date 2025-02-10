using GreenwichCommunityTheatre.Application.DTOs.Reservation;
using GreenwichCommunityTheatre.Domain;

namespace GreenwichCommunityTheatre.Application.Services.Interfaces.Reservation
{
    public interface IReservationService
    {
        Task<ApiResponse<ReservationResponseDto>> CreateReservationAsync(CreateReservationDto createReservationDto);
    }
}
