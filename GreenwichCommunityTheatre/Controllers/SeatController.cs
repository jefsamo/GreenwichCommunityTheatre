using GreenwichCommunityTheatre.Application.DTOs.Play;
using GreenwichCommunityTheatre.Application.DTOs.Seat;
using GreenwichCommunityTheatre.Application.Services.Interfaces.Seat;
using GreenwichCommunityTheatre.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GreenwichCommunityTheatre.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatController : ControllerBase
    {
        private readonly ISeatService _seatService;
        public SeatController(ISeatService seatService)
        {
            _seatService = seatService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetSeats()
        {
            var response = await _seatService.GetAllSeatAsync();

            if (response.Succeeded)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetSeatById(string id)
        {
            var response = await _seatService.GetSeatAsync(id);

            if (response.Succeeded)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [Authorize(Roles = "Operator")]
        [CustomAuthorizeFilter]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSeatById(string id, UpdateSeatDto updateSeatDto)
        {
            var response = await _seatService.UpdateSeatAsync(id, updateSeatDto);

            if (response.Succeeded)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [Authorize(Roles = "Operator")]
        [CustomAuthorizeFilter]
        [HttpPost]
        public async Task<IActionResult> CreateSeat([FromBody] CreateSeatDto createSeatDto)
        {
            var response = await _seatService.CreateSeatAsync(createSeatDto);

            if (response.Succeeded)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [Authorize(Roles = "Operator")]
        [CustomAuthorizeFilter]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeatById(string id)
        {
            var response = await _seatService.DeleteSeatAsync(id);

            if (response.Succeeded)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
    }
}
