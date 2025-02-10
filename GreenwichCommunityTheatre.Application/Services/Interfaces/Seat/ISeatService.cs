using GreenwichCommunityTheatre.Application.DTOs.Play;
using GreenwichCommunityTheatre.Application.DTOs.Seat;
using GreenwichCommunityTheatre.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenwichCommunityTheatre.Application.Services.Interfaces.Seat
{
    public interface ISeatService
    {
        Task<ApiResponse<SeatResponseDto>> CreateSeatAsync(CreateSeatDto createSeatDto);
        Task<ApiResponse<SeatResponseDto>> UpdateSeatAsync(string id, UpdateSeatDto updateSeatDto);
        Task<ApiResponse<SeatResponseDto>> GetSeatAsync(string id);
        Task<ApiResponse<SeatResponseDto>> DeleteSeatAsync(string id);
        Task<ApiResponse<IEnumerable<SeatResponseDto>>> GetAllSeatAsync();
    }
}
