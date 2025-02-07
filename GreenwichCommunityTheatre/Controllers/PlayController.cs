using GreenwichCommunityTheatre.Application.DTOs.Auth;
using GreenwichCommunityTheatre.Application.DTOs.Play;
using GreenwichCommunityTheatre.Application.Services.Interfaces.Play;
using GreenwichCommunityTheatre.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GreenwichCommunityTheatre.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayController : ControllerBase
    {
        private readonly IPlayService _playService;
        public PlayController(IPlayService playService)
        {
            _playService = playService;
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetPlays()
        {
            var response = await _playService.GetAllPlayAsync();

            if (response.Succeeded)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPlayById(string id)
        {
            var response = await _playService.GetPlayAsync(id);

            if (response.Succeeded)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [Authorize(Roles = "Operator")]
        [CustomAuthorizeFilter]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlayById(string id, UpdatePlayDto updatePlayDto)
        {
            var response = await _playService.UpdatePlayAsync(id, updatePlayDto);

            if (response.Succeeded)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [Authorize(Roles = "Operator")]
        [CustomAuthorizeFilter]
        [HttpPost]
        public async Task<IActionResult> CreatePlay([FromBody] CreatePlayDto createPlayDto)
        {
            var response = await _playService.CreatePlayAsync(createPlayDto);

            if (response.Succeeded)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [Authorize(Roles = "Operator")]
        [CustomAuthorizeFilter]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayById(string id)
        {
            var response = await _playService.UpdatePlayAsync(id, updatePlayDto);

            if (response.Succeeded)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

    }
}
