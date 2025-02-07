using AutoMapper;
using GreenwichCommunityTheatre.Application.DTOs.Auth;
using GreenwichCommunityTheatre.Application.Services.Interfaces.Auth;
using GreenwichCommunityTheatre.Domain;
using GreenwichCommunityTheatre.Domain.Entities;
using GreenwichCommunityTheatre.Domain.Entities.Enums;
using GreenwichCommunityTheatre.Infrastructure.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using SerilogTimings;

namespace GreenwichCommunityTheatre.Application.Services.Implementations.Auth
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly ILogger<AuthService> _logger;
        private readonly IMapper _mapper;
        private readonly GctDbContext _gctDbContext;
        private readonly IJwtService _jwtService;
        private readonly IDiagnosticContext _diagnosticContext;

        public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager, ILogger<AuthService> logger, IMapper mapper, GctDbContext gctDbContext, IJwtService jwtService, IDiagnosticContext diagnosticContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _logger = logger;
            _mapper = mapper;
            _gctDbContext = gctDbContext;
            _jwtService = jwtService;
            _diagnosticContext = diagnosticContext;
        }
        public async Task<ApiResponse<LoginResponseDto>> LoginAsync(LoginDto loginDto)
        {
            try
            {
                using (Operation.Time("Time taken to login a user"))
                {
                    var user = await _userManager.FindByEmailAsync(loginDto.Email);
                    if (user == null)
                        return ApiResponse<LoginResponseDto>.Failed("User not found.", StatusCodes.Status404NotFound, new List<string>());

                    var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, lockoutOnFailure: false);

                    if (!result.Succeeded)
                    {
                        return ApiResponse<LoginResponseDto>.Failed("Invalid email or password. Please try again!", StatusCodes.Status400BadRequest, []);
                    }

                    var roles = await _userManager.GetRolesAsync(user);
                    var userRoles = await Task.WhenAll(roles.Select(roleName => _roleManager.FindByNameAsync(roleName)));
                    var token = await _jwtService.CreateJwtToken(user);
                    var responseDto = new LoginResponseDto()
                    {
                        Email = user.Email!,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Role = userRoles.FirstOrDefault()!.Name ?? "Customer",
                        Token = token
                    };

                    return ApiResponse<LoginResponseDto>.Success("Logged in successfully", StatusCodes.Status200OK, responseDto);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some error occurred while logging in." + ex.Message);
                return ApiResponse<LoginResponseDto>.Failed("Some error occurred while logging in." + ex.Message, StatusCodes.Status500InternalServerError, new List<string>() { ex.Message });
            }
        }

        public async Task<ApiResponse<RegisterResponseDto>> RegisterAsync(RegisterDto registerDto)
        {
            try
            {
                using (Operation.Time("Time taken to register a user"))
                {
                    var existingUser = await _userManager.FindByEmailAsync(registerDto.Email);
                    if (existingUser != null)
                    {
                        return ApiResponse<RegisterResponseDto>.Failed("User with this email already exists!", StatusCodes.Status400BadRequest, []);
                    }

                    bool phoneNumberExists = await _gctDbContext.Users.AnyAsync(user => user.PhoneNumber == registerDto.PhoneNumber);
                    if (phoneNumberExists)
                    {
                        return ApiResponse<RegisterResponseDto>.Failed("User with this phone number already exists!", StatusCodes.Status400BadRequest, []);
                    }

                    //var defaultUsername = $"{registerDto.FirstName[0]}{registerDto.LastName[0]}";

                    var newUser = new User { FirstName = registerDto.FirstName, LastName = registerDto.LastName, PhoneNumber = registerDto.PhoneNumber, Email = registerDto.Email, UserName = registerDto.Email };
                    var result = await _userManager.CreateAsync(newUser, registerDto.Password!);

                    if (!result.Succeeded)
                    {
                        var errors = result.Errors.Select(error => error.Description).ToList();
                        return ApiResponse<RegisterResponseDto>.Failed("Unable to register user", StatusCodes.Status400BadRequest, errors);
                    }

                    if (registerDto.Role == UserType.Operator.ToString())
                    {
                        if (await _roleManager.FindByNameAsync(UserType.Operator.ToString()) is null)
                        {
                            var appRole = new Role() { Name = UserType.Operator.ToString() };
                            await _roleManager.CreateAsync(appRole);
                        }

                        await _userManager.AddToRoleAsync(newUser, UserType.Operator.ToString());
                    }

                    if (registerDto.Role == UserType.Customer.ToString())
                    {
                        if (await _roleManager.FindByNameAsync(UserType.Customer.ToString()) is null)
                        {
                            var appRole = new Role() { Name = UserType.Customer.ToString() };
                            await _roleManager.CreateAsync(appRole);
                        }

                        await _userManager.AddToRoleAsync(newUser, UserType.Customer.ToString());
                    }

                    if (registerDto.Role == UserType.SocialClub.ToString())
                    {
                        if (await _roleManager.FindByNameAsync(UserType.SocialClub.ToString()) is null)
                        {
                            var appRole = new Role() { Name = UserType.SocialClub.ToString() };
                            await _roleManager.CreateAsync(appRole);
                        }

                        await _userManager.AddToRoleAsync(newUser, UserType.SocialClub.ToString());
                    }

                    var userResponse = _mapper.Map<RegisterResponseDto>(newUser);
                    var token = await _jwtService.CreateJwtToken(newUser);
                    userResponse.Token = token;
                    userResponse.Role = registerDto.Role;

                    return ApiResponse<RegisterResponseDto>.Success("User created successfully", StatusCodes.Status200OK, userResponse);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some error occurred while logging in." + ex.Message);
                return ApiResponse<RegisterResponseDto>.Failed("Some error occurred while logging in." + ex.Message, StatusCodes.Status500InternalServerError, new List<string>() { ex.Message });
            }
        }
    }
}
