using AutoMapper;
using GreenwichCommunityTheatre.Application.DTOs.Play;
using GreenwichCommunityTheatre.Application.DTOs.Review;
using GreenwichCommunityTheatre.Application.Services.Interfaces.Review;
using GreenwichCommunityTheatre.Domain;
using GreenwichCommunityTheatre.Domain.Entities;
using GreenwichCommunityTheatre.Infrastructure.Context;
using GreenwichCommunityTheatre.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SerilogTimings;
using System.Numerics;
using System.Security.Claims;

namespace GreenwichCommunityTheatre.Application.Services.Implementations.Review
{
    public class ReviewService : IReviewService
    {
        private readonly IMapper _mapper;
        private readonly GctDbContext _gctDbContext;
        private readonly ILogger<ReviewService> _logger;
        private readonly IGenericRepository<GreenwichCommunityTheatre.Domain.Entities.Play> _playRepository;
        private readonly IGenericRepository<GreenwichCommunityTheatre.Domain.Entities.Review> _reviewRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;

        public ReviewService(IMapper mapper, GctDbContext gctDbContext, ILogger<ReviewService> logger, IGenericRepository<GreenwichCommunityTheatre.Domain.Entities.Play> playRepository, IGenericRepository<GreenwichCommunityTheatre.Domain.Entities.Review> reviewRepository, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
        {
            _mapper = mapper;
            _gctDbContext = gctDbContext;
            _playRepository = playRepository;
            _reviewRepository = reviewRepository;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }
        public async Task<ApiResponse<ReviewResponseDto>> CreateReviewAsync(CreateReviewDto createReviewDto)
        {

            try
            {
                using (Operation.Time("Time taken to create a review"))
                {
                    var userId = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value.ToString();

                    var user = await _userManager.FindByIdAsync(userId!);

                    var playId = createReviewDto.PlayId;
                    var play = await _playRepository.GetByIdAsync(playId);

                    if (play is null)
                    {
                        return ApiResponse<ReviewResponseDto>.Failed("Play not found", StatusCodes.Status404NotFound, []);
                    }

                    var review = _mapper.Map<GreenwichCommunityTheatre.Domain.Entities.Review>(createReviewDto);
                    review.UserId = Guid.Parse(userId!);

                    await _reviewRepository.AddAsync(review);
                    await _reviewRepository.SaveChangesAsync();

                    var reviewDto = _mapper.Map<ReviewResponseDto>(review);
                    return ApiResponse<ReviewResponseDto>.Success("Review created succcessfully", StatusCodes.Status201Created, reviewDto);

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some error occurred while creating review." + ex.Message);
                return ApiResponse<ReviewResponseDto>.Failed("Some error occurred while creating review." + ex.Message, StatusCodes.Status500InternalServerError, new List<string>() { ex.Message });
            }

        }

        public Task<ApiResponse<ReviewResponseDto>> GetReview(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<ReviewResponseDto>> UpdateReviewAsync(string id, UpdateReviewDto updateReviewDto)
        {
            try
            {
                using (Operation.Time("Time taken to create a review"))
                {

                    var review = await _reviewRepository.GetByIdAsync(id);

                    if (review is null)
                    {
                        return ApiResponse<ReviewResponseDto>.Failed("Review not found", StatusCodes.Status404NotFound, []);
                    }
                    var userId = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value.ToString();

                    var currentUserId = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                    var isOperator = _httpContextAccessor.HttpContext!.User.IsInRole("Operator");
                    if (!review.UserId.ToString().Equals(currentUserId, StringComparison.OrdinalIgnoreCase) && !isOperator)
                    {
                        return ApiResponse<ReviewResponseDto>.Failed("Review not found", StatusCodes.Status403Forbidden, []);
                    }

                    review.Rating = updateReviewDto.Rating;
                    review.Comment = updateReviewDto.Comment;
                    review.UpdatedAt = DateTimeOffset.UtcNow;
                    await _reviewRepository.SaveChangesAsync();

                    var reviewDto = _mapper.Map<ReviewResponseDto>(review);
                    return ApiResponse<ReviewResponseDto>.Success("Review updated succcessfully", StatusCodes.Status201Created, reviewDto);

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some error occurred while updating review." + ex.Message);
                return ApiResponse<ReviewResponseDto>.Failed("Some error occurred while updating review." + ex.Message, StatusCodes.Status500InternalServerError, new List<string>() { ex.Message });
            }
        }
        public Task<ApiResponse<ReviewResponseDto>> DeleteReview(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<IEnumerable<ReviewResponseDto>>> GetReviewsByPlayId(string playId)
        {
            try
            {
                using (Operation.Time("Time taken to get all reviews for a play"))
                {
                    var reviews = await _reviewRepository.GetAllAsync((p) => p.PlayId == playId);
                    var reviewsDto = _mapper.Map<IEnumerable<ReviewResponseDto>>(reviews);
                    return ApiResponse<IEnumerable<ReviewResponseDto>>.Success("All reviews for this play retrieved succcessfully", StatusCodes.Status201Created, reviewsDto);
                }
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Some error occurred while updating review." + ex.Message);
                return ApiResponse<IEnumerable<ReviewResponseDto>>.Failed("Some error occurred while updating review." + ex.Message, StatusCodes.Status500InternalServerError, new List<string>() { ex.Message });
            }
           
        }
    }
}
