using System.ComponentModel.DataAnnotations.Schema;

namespace GreenwichCommunityTheatre.Domain.Entities
{
    public class Shipment : BaseEntity
    {
        public required string ReservationId { get; set; }
        public bool IsDelivered { get; set; } = false;

        [ForeignKey("ReservationId")]
        public Reservation? Reservation { get; set; }
    }
}
