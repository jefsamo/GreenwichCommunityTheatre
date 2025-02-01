using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenwichCommunityTheatre.Domain.Entities
{
    public class Play : BaseEntity
    {
        public required string Title { get; set; }
        public required string ImageUrl { get; set; }
        public required double Price { get; set; }
        public required DateTimeOffset Time { get; set; }
        public required int TotalSeats { get; set; } = 100;
        public required int AvailableSeats { get; set; }
    }
}
