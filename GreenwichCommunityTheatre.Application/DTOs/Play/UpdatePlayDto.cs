using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenwichCommunityTheatre.Application.DTOs.Play
{
    public class UpdatePlayDto
    {
        [Required(ErrorMessage = "A play must have a title")]
        public required string Title { get; set; }

        [Required(ErrorMessage = "A play must have an image")]
        public required string ImageUrl { get; set; }

        [Required(ErrorMessage = "A play must have a description")]
        public required string Description { get; set; }

        [Required(ErrorMessage = "A play must have a main image url")]
        public required string MainImageUrl { get; set; }
        [Required(ErrorMessage = "A play must have a price")]
        public required double Price { get; set; }
        public int TotalSeats { get; set; } = 100;

        [Required(ErrorMessage = "A play must have a start time")]
        public required DateTimeOffset TimeOfPlay { get; set; }
    }
}
