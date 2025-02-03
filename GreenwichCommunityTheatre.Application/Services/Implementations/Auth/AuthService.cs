using AutoMapper;
using GreenwichCommunityTheatre.Application.DTOs.Auth;
using GreenwichCommunityTheatre.Application.Services.Interfaces.Auth;
using GreenwichCommunityTheatre.Domain;
using GreenwichCommunityTheatre.Domain.Entities;
using GreenwichCommunityTheatre.Infrastructure.Context;
using Microsoft.AspNetCore.Identity;

namespace GreenwichCommunityTheatre.Application.Services.Implementations.Auth
{
    public class AuthService : IAuthService
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IMapper _mapper;
        private readonly GctDbContext _gctDbContext;
        private readonly IJwtService _jwtService;


        public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager, IMapper mapper, GctDbContext gctDbContext, IJwtService jwtService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _gctDbContext = gctDbContext;
            _jwtService = jwtService;
        }
        public Task<ApiResponse<LoginResponseDto>> LoginAsync(LoginDto loginDto)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<LoginResponseDto>> RegisterAsync(RegisterDto registerDto)
        {
            throw new NotImplementedException();
        }
    }
}
