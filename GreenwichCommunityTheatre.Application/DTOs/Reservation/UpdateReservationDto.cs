using GreenwichCommunityTheatre.Domain.Entities.Enums;
using GreenwichCommunityTheatre.Domain.Entities;

namespace GreenwichCommunityTheatre.Application.DTOs.Reservation
{
    public class UpdateReservationDto
    {
        public required bool HasPaid { get; set; }
    }
}
