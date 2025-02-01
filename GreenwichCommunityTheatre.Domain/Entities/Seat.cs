namespace GreenwichCommunityTheatre.Domain.Entities
{
    public class Seat : BaseEntity
    {
        public required string SeatNumber { get; set; }
        public required double Price { get; set; }
    }
}
