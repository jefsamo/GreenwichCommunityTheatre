using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenwichCommunityTheatre.Domain.Entities
{
    public class Ticket : BaseEntity
    {
        public required string ReservationId { get; set; }
        public required string PlayId { get; set; }
        public required string SeatId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required DateOnly DateOfBirth { get; set; }
        public required bool HasCheckedIn { get; set; } = false;
        public required string TicketCode { get; set; }

        [ForeignKey("ReservationId")]
        public Reservation? Reservation { get; set; }

        [ForeignKey("PlayId")]
        public Play? Play { get; set; }

        [ForeignKey("SeatId")]
        public Seat? Seat { get; set; }
    }
}
