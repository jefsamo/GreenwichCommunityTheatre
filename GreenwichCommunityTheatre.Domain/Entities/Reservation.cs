using GreenwichCommunityTheatre.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenwichCommunityTheatre.Domain.Entities
{
    public class Reservation : BaseEntity
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required Guid UserId { get; set; }
        public required string Email { get; set; }
        public bool HasPaid { get; set; } = false;
        public ShippingOption ShippingOption { get; set; } = ShippingOption.Pickup;
        public virtual ICollection<Ticket> Tickets { get; set; }
        public Shipment Shipment { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }
    }
}
