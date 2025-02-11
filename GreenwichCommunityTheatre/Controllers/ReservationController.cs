using GreenwichCommunityTheatre.Application.DTOs.Play;
using GreenwichCommunityTheatre.Application.DTOs.Reservation;
using GreenwichCommunityTheatre.Application.Services.Interfaces.Reservation;
using Microsoft.AspNetCore.Mvc;

namespace GreenwichCommunityTheatre.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;   
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation([FromBody] CreateReservationDto createReservationDto)
        {
            var response = await _reservationService.CreateReservationAsync(createReservationDto);

            if (response.Succeeded)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAReservation(string id)
        {
            var response = await _reservationService.GetAReservationAsync(id);

            if (response.Succeeded)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
    }
}
