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
        Task<ApiResponse<IEnumerable<TicketResponseDto>>> GetAllTicketsAsync();
        Task<ApiResponse<IEnumerable<TicketResponseDto>>> GetAllTicketsByReservationIdAsync(string id);
        Task<ApiResponse<IEnumerable<ReservationResponseDto<TicketResponseDto>>>> GetAllReservationsByUserAsync();
        Task<ApiResponse<IEnumerable<ReservationResponseDto<TicketResponseDto>>>> GetAllReservationsAsync();

    }
}
