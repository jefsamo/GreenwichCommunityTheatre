namespace GreenwichCommunityTheatre.Application.DTOs.Review
{
    public class ReviewResponseDto
    {
        public required string Id { get; set; }
        public required int Rating { get; set; }
        public required string PlayId { get; set; }
        public required Guid UserId { get; set; }
        public required string Comment { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
