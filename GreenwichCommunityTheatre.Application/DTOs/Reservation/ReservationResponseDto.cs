using GreenwichCommunityTheatre.Domain.Entities.Enums;
using GreenwichCommunityTheatre.Domain.Entities;

namespace GreenwichCommunityTheatre.Application.DTOs.Reservation
{
    public class ReservationResponseDto<T>
    {
        public string? Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public Guid UserId { get; set; }
        public required string Email { get; set; }
        public bool HasPaid { get; set; } = false;
        public List<T>? Tickets { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
