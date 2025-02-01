using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenwichCommunityTheatre.Domain.Entities
{
    public class Ticket : BaseEntity
    {
        public required string ReservationId { get; set; }
        public required string PlayId { get; set; }
        public required string SeatId { get; set; }
        public required string CustomerName { get; set; }
        public required int Age { get; set; }

        [ForeignKey("ReservationId")]
        public Reservation? Reservation { get; set; }

        [ForeignKey("PlayId")]
        public Play? Play { get; set; }

        [ForeignKey("SeatId")]
        public Seat? Seat { get; set; }
    }
}
