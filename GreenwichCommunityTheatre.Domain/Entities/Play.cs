﻿namespace GreenwichCommunityTheatre.Domain.Entities
{
    public class Play : BaseEntity
    {
        public required string Title { get; set; }
        public required string ImageUrl { get; set; }
        public required string Description { get; set; }
        public required string MainImageUrl { get; set; }
        public required double Price { get; set; }
        public required DateTimeOffset TimeOfPlay { get; set; }
        public int TotalSeats { get; set; } = 100;
        public int? AvailableSeats { get; set; }
        public ICollection<Review> Reviews { get; set;} = new List<Review>();
        public ICollection<Ticket> Tickets { get; set;} = new List<Ticket>();
    }
}
