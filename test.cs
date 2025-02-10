using AutoMapper;
using GreenwichCommunityTheatre.Application.DTOs.Reservation;
using GreenwichCommunityTheatre.Application.DTOs.Ticket;
using GreenwichCommunityTheatre.Application.Services.Interfaces.Reservation;
using GreenwichCommunityTheatre.Domain;
using GreenwichCommunityTheatre.Domain.Entities;
using GreenwichCommunityTheatre.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SerilogTimings;
using System.Security.Claims;

namespace GreenwichCommunityTheatre.Application.Services.Implementations.Reservation
{
    public class ReservationService : IReservationService
    {
        private readonly IMapper _mapper;
        private readonly ILogger<ReservationService> _logger;
        private readonly IGenericRepository<Reservation> _reservationRepository;
        private readonly IGenericRepository<Ticket> _ticketRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;

        public ReservationService(
            IMapper mapper,
            ILogger<ReservationService> logger,
            IGenericRepository<Reservation> reservationRepository,
            IGenericRepository<Ticket> ticketRepository,
            IHttpContextAccessor httpContextAccessor,
            UserManager<User> userManager)
        {
            _mapper = mapper;
            _logger = logger;
            _reservationRepository = reservationRepository;
            _ticketRepository = ticketRepository;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<ApiResponse<ReservationResponseDto>> CreateReservationAsync(CreateReservationDto createReservationDto)
        {
            try
            {
                using (Operation.Time("Time taken to create a reservation"))
                {
                    // Retrieve user ID from Bearer Token
                    var userId = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    if (string.IsNullOrEmpty(userId))
                    {
                        return ApiResponse<ReservationResponseDto>.Failed("User not authenticated", StatusCodes.Status401Unauthorized, []);
                    }

                    // Fetch user from database
                    var user = await _userManager.FindByIdAsync(userId);
                    if (user == null)
                    {
                        return ApiResponse<ReservationResponseDto>.Failed("User not found", StatusCodes.Status404NotFound, []);
                    }

                    // Create a new Reservation entity
                    var reservation = new Reservation
                    {
                        FirstName = createReservationDto.FirstName,
                        LastName = createReservationDto.LastName,
                        Email = createReservationDto.Email,
                        UserId = Guid.Parse(userId),
                        Tickets = new List<Ticket>() // Initialize empty list
                    };

                    await _reservationRepository.AddAsync(reservation);
                    await _reservationRepository.SaveChangesAsync();

                    // Assign ReservationId to each Ticket and Map to Entity
                    var ticketEntities = _mapper.Map<List<Ticket>>(createReservationDto.Tickets);
                    foreach (var ticket in ticketEntities)
                    {
                        ticket.ReservationId = reservation.Id;
                    }

                    await _ticketRepository.AddRangeAsync(ticketEntities);
                    await _ticketRepository.SaveChangesAsync();

                    // ✅ Map to DTOs for API response
                    var reservationResponse = new ReservationResponseDto
                    {
                        Id = reservation.Id,
                        FirstName = reservation.FirstName,
                        LastName = reservation.LastName,
                        Email = reservation.Email,
                        Tickets = _mapper.Map<List<TicketResponseDto>>(ticketEntities) // Prevents object cycles
                    };

                    return ApiResponse<ReservationResponseDto>.Success("Reservation created successfully", StatusCodes.Status201Created, reservationResponse);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some error occurred while creating reservation: " + ex.Message);
                return ApiResponse<ReservationResponseDto>.Failed(
                    "Some error occurred while creating reservation: " + ex.Message,
                    StatusCodes.Status500InternalServerError,
                    new List<string> { ex.Message }
                );
            }
        }
    }
}
