using GreenwichCommunityTheatre.Domain.Entities.Enums;
using GreenwichCommunityTheatre.Domain.Entities;

namespace GreenwichCommunityTheatre.Application.DTOs.Reservation
{
    public class UpdateReservationDto
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required Guid UserId { get; set; }
        public required string Email { get; set; }
        public ShippingOption ShippingOption { get; set; } = ShippingOption.Pickup;
        public List<Ticket> Tickets { get; set; }
    }
}
