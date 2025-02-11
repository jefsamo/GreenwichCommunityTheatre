using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenwichCommunityTheatre.Application.DTOs.Reservation
{
    public class ReservationTicketResponseDto
    {
        public required string Title { get; set; }
        public required string ImageUrl { get; set; }
        public required double PlayPrice { get; set; }
        public required string SeatNumber { get; set; }
        public required double SeatPrice { get; set; }
        public required string CustomerName { get; set; }
        public required DateOnly DateOfBirth { get; set; }
    }
}
