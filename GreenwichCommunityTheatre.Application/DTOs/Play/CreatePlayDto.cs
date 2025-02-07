using System.ComponentModel.DataAnnotations;

namespace GreenwichCommunityTheatre.Application.DTOs.Play
{
    public class CreatePlayDto
    {
        [Required(ErrorMessage = "A play must have a title")]
        public required string Title { get; set; }

        [Required(ErrorMessage = "A play must have an image")]
        public required string ImageUrl { get; set; }

        [Required(ErrorMessage = "A play must have a price")]
        public required double Price { get; set; }
        public int TotalSeats { get; set; } = 100;

        [Required(ErrorMessage = "A play must have a start time")]
        public required DateTimeOffset TimeOfPlay { get; set; }

    }
}
