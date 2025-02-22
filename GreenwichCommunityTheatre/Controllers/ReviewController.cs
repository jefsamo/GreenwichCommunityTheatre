using GreenwichCommunityTheatre.Application.DTOs.Review;
using GreenwichCommunityTheatre.Application.Services.Interfaces.Review;
using GreenwichCommunityTheatre.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GreenwichCommunityTheatre.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [Authorize(Roles = "Operator, Customer")]
        //[CustomAuthorizeFilter]
        [HttpPost]
        public async Task<IActionResult> CreateReview([FromBody] CreateReviewDto createReviewDto)
        {
            var response = await _reviewService.CreateReviewAsync(createReviewDto);

            if (response.Succeeded)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [Authorize(Roles = "Operator, Customer")]
        [CustomAuthorizeFilter]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReview(string id, [FromBody] UpdateReviewDto updateReviewDto)
        {
            var response = await _reviewService.UpdateReviewAsync(id, updateReviewDto);

            if (response.Succeeded)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [AllowAnonymous]
        [HttpGet("{playId}/reviews")]
        public async Task<IActionResult> GetReviewByPlayId(string playId)
        {
            var response = await _reviewService.GetReviewsByPlayId(playId);

            if (response.Succeeded)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
    }
}
