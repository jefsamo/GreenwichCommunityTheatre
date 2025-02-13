using GreenwichCommunityTheatre.Application.Services.Implementations.Auth;
using GreenwichCommunityTheatre.Application.Services.Implementations.Play;
using GreenwichCommunityTheatre.Application.Services.Implementations.Reservation;
using GreenwichCommunityTheatre.Application.Services.Implementations.Review;
using GreenwichCommunityTheatre.Application.Services.Implementations.Seat;
using GreenwichCommunityTheatre.Application.Services.Interfaces.Auth;
using GreenwichCommunityTheatre.Application.Services.Interfaces.Play;
using GreenwichCommunityTheatre.Application.Services.Interfaces.Reservation;
using GreenwichCommunityTheatre.Application.Services.Interfaces.Review;
using GreenwichCommunityTheatre.Application.Services.Interfaces.Seat;
using GreenwichCommunityTheatre.Domain.Entities;
using GreenwichCommunityTheatre.Infrastructure.Context;
using GreenwichCommunityTheatre.Infrastructure.Repositories.Implementations;
using GreenwichCommunityTheatre.Infrastructure.Repositories.Interfaces;
using GreenwichCommunityTheatre.Mapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace GreenwichCommunityTheatre.Extensions
{
    public static class DIServiceExtension
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IPlayService, PlayService>();
            services.AddScoped<ISeatService, SeatService>();
            services.AddScoped<IReservationService, ReservationService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddAutoMapper(typeof(MapperProfile));
            services.AddDbContext<GctDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"));
            });

            services.AddIdentity<User, Role>().AddEntityFrameworkStores<GctDbContext>().AddDefaultTokenProviders().AddUserStore<UserStore<User,Role,GctDbContext,Guid>>().AddRoleStore<RoleStore<Role, GctDbContext, Guid>>();
            services.AddAuthorization(options =>
            {
                options.FallbackPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build(); //enforces authoriation policy (user must be authenticated) for all the action methods
            });
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateAudience = true,
                    ValidAudience = configuration["Jwt:Audience"],
                    ValidateIssuer = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!))
                };
                options.SaveToken = true;
            });
        }
    }
}
