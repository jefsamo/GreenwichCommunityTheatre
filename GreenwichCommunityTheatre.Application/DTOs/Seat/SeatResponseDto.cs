using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenwichCommunityTheatre.Application.DTOs.Seat
{
    public class SeatResponseDto
    {
        public required string SeatNumber { get; set; }
        public required string Id { get; set; }
        public required double Price { get; set; }
    }
}
