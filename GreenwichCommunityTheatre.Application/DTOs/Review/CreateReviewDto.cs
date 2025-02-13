using System.ComponentModel.DataAnnotations;

namespace GreenwichCommunityTheatre.Application.DTOs.Review
{
    public class CreateReviewDto
    {
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public required int Rating { get; set; }
        public required string PlayId { get; set; }

        [MaxLength(200, ErrorMessage = "Comment must not be greater than 200 characters")]
        public required string Comment { get; set; }
    }
}
