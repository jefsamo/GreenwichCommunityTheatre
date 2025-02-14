using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenwichCommunityTheatre.Application.DTOs.Reservation
{
    public class TicketDto
    {
        public required string PlayId { get; set; }
        public required string SeatId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required DateOnly DateOfBirth { get; set; }
    }
}
