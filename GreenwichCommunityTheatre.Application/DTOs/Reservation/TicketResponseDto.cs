using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenwichCommunityTheatre.Application.DTOs.Reservation
{
    public class TicketResponseDto
    {
        public string? ReservationId { get; set; }
        public string? PlayId { get; set; }
        public string? SeatId { get; set; }
        public string FirstName { get; set; }
        public required string LastName { get; set; }
        public required bool HasCheckedIn { get; set; }
        public required DateOnly DateOfBirth { get; set; }
    }
}
