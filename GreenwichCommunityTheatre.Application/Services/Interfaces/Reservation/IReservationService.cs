using GreenwichCommunityTheatre.Application.DTOs.Reservation;
using GreenwichCommunityTheatre.Domain;

namespace GreenwichCommunityTheatre.Application.Services.Interfaces.Reservation
{
    public interface IReservationService
    {
        Task<ApiResponse<ReservationResponseDto<TicketResponseDto>>> CreateReservationAsync(CreateReservationDto createReservationDto);
        Task<ApiResponse<ReservationResponseDto<ReservationTicketResponseDto>>> GetAReservationAsync(string id);
        Task<ApiResponse<TicketResponseDto>> CheckInTicket(string checkInCode);
        Task<ApiResponse<ReservationResponseDto<TicketResponseDto>>> MarkReservationAsPaidAsync(string id, UpdateReservationDto updateReservationDto);
    }
}
