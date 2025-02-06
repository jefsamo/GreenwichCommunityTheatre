using GreenwichCommunityTheatre.Application.DTOs.Auth;
using GreenwichCommunityTheatre.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenwichCommunityTheatre.Application.Services.Interfaces.Auth
{
    public interface IAuthService
    {
        Task<ApiResponse<LoginResponseDto>> LoginAsync(LoginDto loginDto);
        Task<ApiResponse<RegisterResponseDto>> RegisterAsync(RegisterDto registerDto);
    }
}
