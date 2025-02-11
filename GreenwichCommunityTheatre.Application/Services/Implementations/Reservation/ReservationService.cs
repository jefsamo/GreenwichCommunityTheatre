using AutoMapper;
using GreenwichCommunityTheatre.Application.DTOs.Reservation;
using GreenwichCommunityTheatre.Application.DTOs.Seat;
using GreenwichCommunityTheatre.Application.Services.Implementations.Seat;
using GreenwichCommunityTheatre.Application.Services.Interfaces.Reservation;
using GreenwichCommunityTheatre.Domain;
using GreenwichCommunityTheatre.Domain.Entities;
using GreenwichCommunityTheatre.Infrastructure.Context;
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
        private readonly GctDbContext _gctDbContext;
        private readonly ILogger<ReservationService> _logger;
        private readonly IGenericRepository<GreenwichCommunityTheatre.Domain.Entities.Reservation> _reservationRepository;
        private readonly IGenericRepository<GreenwichCommunityTheatre.Domain.Entities.Ticket> _ticketRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;


        public ReservationService(IMapper mapper, GctDbContext gctDbContext, ILogger<ReservationService> logger, IGenericRepository<GreenwichCommunityTheatre.Domain.Entities.Reservation> reservationRepository, IGenericRepository<GreenwichCommunityTheatre.Domain.Entities.Ticket> ticketRepository, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
        {
            _mapper = mapper;
            _gctDbContext = gctDbContext;
            _logger = logger;
            _reservationRepository = reservationRepository;
            _ticketRepository = ticketRepository;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<ApiResponse<ReservationResponseDto<TicketResponseDto>>> CreateReservationAsync(CreateReservationDto createReservationDto)
        {
            try
            {
                using (Operation.Time("Time taken to create a reservation"))
                {
                    var userId = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value.ToString();

                    var user = await _userManager.FindByIdAsync(userId!);

                    var reservation = new GreenwichCommunityTheatre.Domain.Entities.Reservation
                    {
                        FirstName = createReservationDto.FirstName,
                        LastName = createReservationDto.LastName,
                        Email = createReservationDto.Email,
                        UserId = Guid.Parse(userId!),
                        Tickets = new List<Ticket>()
                    };

                    await _reservationRepository.AddAsync(reservation);
                    await _reservationRepository.SaveChangesAsync();

                    var ticketEntities = _mapper.Map<List<Ticket>>(createReservationDto.Tickets);
                    foreach (var ticket in ticketEntities)
                    {
                        ticket.ReservationId = reservation.Id;
                    }

                    await _ticketRepository.AddRangeAsync(ticketEntities);
                    await _ticketRepository.SaveChangesAsync();

                    var reservationResponse = new ReservationResponseDto<TicketResponseDto>
                    {
                        FirstName = reservation.FirstName,
                        LastName = reservation.LastName,
                        Email = reservation.Email,
                        UserId = Guid.Parse(userId!),
                        Tickets = _mapper.Map<List<TicketResponseDto>>(ticketEntities)
                    };

                    return ApiResponse<ReservationResponseDto<TicketResponseDto>>.Success("Reservation created successfully", StatusCodes.Status201Created, reservationResponse);

                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some error occurred while creating reservation." + ex.Message);
                return ApiResponse<ReservationResponseDto<TicketResponseDto>>.Failed("Some error occurred while creating reservation." + ex.Message, StatusCodes.Status500InternalServerError, new List<string>() { ex.Message });
            }
        }

        public async Task<ApiResponse<ReservationResponseDto<ReservationTicketResponseDto>>> GetAReservationAsync(string id)
        {
            try
            {
                using (Operation.Time("Time taken to create a reservation"))
                { 
                    var reservation = await _reservationRepository.GetByIdAsync(id);

                    if(reservation is null)
                    {
                       return ApiResponse<ReservationResponseDto<ReservationTicketResponseDto>>.Failed("Reservation not found", StatusCodes.Status404NotFound, []);
                    }

                    var tickets = await _ticketRepository.GetAllAsync(t => t.ReservationId == reservation.Id);
                    //var ticketList = new List<ReservationTicketResponseDto>();

                    // Map tickets to ReservationTicketResponseDto
                    var mappedTickets = _mapper.Map<List<ReservationTicketResponseDto>>(tickets);

                    // Construct the response DTO
                    var reservationResponse = new ReservationResponseDto<ReservationTicketResponseDto>
                    {
                        FirstName = reservation.FirstName,
                        LastName = reservation.LastName,
                        Email = reservation.Email,
                        UserId = reservation.UserId,
                        HasPaid = reservation.HasPaid,
                        ShippingOption = reservation.ShippingOption,
                        Tickets = mappedTickets
                    };

                    return ApiResponse<ReservationResponseDto<ReservationTicketResponseDto>>.Success("Reservation retrieved succcessfully", StatusCodes.Status200OK, reservationResponse);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some error occurred while retrieving reservation." + ex.Message);
                return ApiResponse<ReservationResponseDto<ReservationTicketResponseDto>>.Failed("Some error occurred while retrieving reservation." + ex.Message, StatusCodes.Status500InternalServerError, new List<string>() { ex.Message });
            }
        }
    }
}
