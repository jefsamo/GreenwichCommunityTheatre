﻿namespace GreenwichCommunityTheatre.Application.DTOs.Play
{
    public class PlayResponseDto
    {
        public required string Id { get; set; }
        public required string Title { get; set; }
        public required string ImageUrl { get; set; }
        public required double Price { get; set; }
        public required string Description { get; set; }
        public required string MainImageUrl { get; set; }
        public required DateTimeOffset TimeOfPlay { get; set; }
        public int TotalSeats { get; set; }
        public int AvailableSeats { get; set; }
    }
}
