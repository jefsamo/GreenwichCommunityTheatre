using GreenwichCommunityTheatre.Application.DTOs.Review;
using GreenwichCommunityTheatre.Domain;

namespace GreenwichCommunityTheatre.Application.Services.Interfaces.Review
{
    public interface IReviewService
    {
        Task<ApiResponse<ReviewResponseDto>> CreateReviewAsync(CreateReviewDto createReviewDto);
        Task<ApiResponse<ReviewResponseDto>> UpdateReviewAsync(string id, UpdateReviewDto updateReviewDto);
        Task<ApiResponse<ReviewResponseDto>> GetReview(string id);
        Task<ApiResponse<IEnumerable<ReviewResponseDto>>> GetReviewsByPlayId(string playId);
        Task<ApiResponse<ReviewResponseDto>> DeleteReview(string id);

    }
}
