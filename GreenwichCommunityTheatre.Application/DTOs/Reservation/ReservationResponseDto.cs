using GreenwichCommunityTheatre.Domain.Entities.Enums;
using GreenwichCommunityTheatre.Domain.Entities;

namespace GreenwichCommunityTheatre.Application.DTOs.Reservation
{
    public class ReservationResponseDto
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required Guid UserId { get; set; }
        public required string Email { get; set; }
        public bool HasPaid { get; set; } = false;
        public ShippingOption ShippingOption { get; set; } = ShippingOption.Pickup;
        public List<TicketResponseDto> Tickets { get; set; }
    }
}
