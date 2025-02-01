namespace GreenwichCommunityTheatre.Domain.Entities
{
    public class Reservation : BaseEntity
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public bool HasPaid { get; set; } = false;
        public ShippingOption ShippingOption { get; set; } = ShippingOption.Pickup;
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
