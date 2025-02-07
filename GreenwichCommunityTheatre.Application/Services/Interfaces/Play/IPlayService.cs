using GreenwichCommunityTheatre.Application.DTOs.Auth;
using GreenwichCommunityTheatre.Application.DTOs.Play;
using GreenwichCommunityTheatre.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenwichCommunityTheatre.Application.Services.Interfaces.Play
{
    public interface IPlayService
    {
        Task<ApiResponse<PlayResponseDto>> CreatePlayAsync(CreatePlayDto createPlayDto);
        Task<ApiResponse<PlayResponseDto>> UpdatePlayAsync(string id, UpdatePlayDto updatePlayDto);
        Task<ApiResponse<PlayResponseDto>> GetPlayAsync(string id);
        Task<ApiResponse<IEnumerable<PlayResponseDto>>> GetAllPlayAsync();
        Task<ApiResponse<PlayResponseDto>> DeletePlayAsync(string id);

    }
}
