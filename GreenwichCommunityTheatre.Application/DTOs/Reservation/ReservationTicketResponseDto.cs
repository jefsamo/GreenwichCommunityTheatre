namespace GreenwichCommunityTheatre.Application.DTOs.Reservation
{
    public class ReservationTicketResponseDto
    {
        public required string Title { get; set; }
        public required string ImageUrl { get; set; }
        public required double PlayPrice { get; set; }
        public required string SeatNumber { get; set; }
        public required double SeatPrice { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required DateOnly DateOfBirth { get; set; }
        public required bool HasCheckedIn { get; set; } = false;
        public required string TicketCode { get; set; }
    }
}
