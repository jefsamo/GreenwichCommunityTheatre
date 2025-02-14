using AutoMapper;
using GreenwichCommunityTheatre.Application.DTOs.Reservation;
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
using System.Text;


namespace GreenwichCommunityTheatre.Application.Services.Implementations.Reservation
{
    public class ReservationService : IReservationService
    {
        private readonly IMapper _mapper;
        private readonly GctDbContext _gctDbContext;
        private readonly ILogger<ReservationService> _logger;
        private readonly IGenericRepository<GreenwichCommunityTheatre.Domain.Entities.Play> _playRepository;
        private readonly IGenericRepository<GreenwichCommunityTheatre.Domain.Entities.Reservation> _reservationRepository;
        private readonly IGenericRepository<GreenwichCommunityTheatre.Domain.Entities.Ticket> _ticketRepository;
        private readonly IGenericRepository<GreenwichCommunityTheatre.Domain.Entities.Seat> _seatRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;

        public ReservationService(IMapper mapper, GctDbContext gctDbContext, ILogger<ReservationService> logger, IGenericRepository<GreenwichCommunityTheatre.Domain.Entities.Reservation> reservationRepository,
            IGenericRepository<GreenwichCommunityTheatre.Domain.Entities.Ticket> ticketRepository, IGenericRepository<GreenwichCommunityTheatre.Domain.Entities.Play> playRepository, IGenericRepository<GreenwichCommunityTheatre.Domain.Entities.Seat> seatRepository, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
        {
            _mapper = mapper;
            _gctDbContext = gctDbContext;
            _logger = logger;
            _reservationRepository = reservationRepository;
            _ticketRepository = ticketRepository;
            _playRepository = playRepository;
            _seatRepository = seatRepository;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<ApiResponse<TicketResponseDto>> CheckInTicket(string checkInCode)
        {
            try
            {
                using (Operation.Time("Time taken to check-in customer"))
                {
                    var ticket = await _ticketRepository.FindSingleAsync((ticket) => ticket.TicketCode == checkInCode);

                    if (ticket == null)
                    {
                        return ApiResponse<TicketResponseDto>.Failed("Ticket not found", StatusCodes.Status404NotFound, []);
                    }

                    if (ticket.HasCheckedIn)
                    {
                        return ApiResponse<TicketResponseDto>.Failed("Ticket already used", StatusCodes.Status400BadRequest, []);
                    }

                    var reservationId = ticket.ReservationId;

                    var reservation = await _reservationRepository.GetByIdAsync(reservationId);

                    if (!reservation.HasPaid)
                    {
                        return ApiResponse<TicketResponseDto>.Failed("Customer has not paid", StatusCodes.Status400BadRequest, []);
                    }

                    ticket.HasCheckedIn = true;
                    await _ticketRepository.SaveChangesAsync();

                    var ticketResponse = new TicketResponseDto
                    {
                        FirstName = ticket.FirstName,
                        LastName = ticket.LastName,
                        HasCheckedIn = ticket.HasCheckedIn,
                        DateOfBirth = ticket.DateOfBirth,
                    };

                    return ApiResponse<TicketResponseDto>.Success("Ticket check-in code succcessfully", StatusCodes.Status200OK, ticketResponse);

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some error occurred while retrieving reservation." + ex.Message);
                return ApiResponse<TicketResponseDto>.Failed("Some error occurred while retrieving reservation." + ex.Message, StatusCodes.Status500InternalServerError, new List<string>() { ex.Message });
            }
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
                    //await _reservationRepository.SaveChangesAsync();

                    var ticketEntities = _mapper.Map<List<Ticket>>(createReservationDto.Tickets);
                    foreach (var ticket in ticketEntities)
                    {
                        ticket.ReservationId = reservation.Id;
                        ticket.TicketCode = GenerateTicketCode();
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
                using (Operation.Time("Time taken to get a reservation"))
                {
                    var reservation = await _reservationRepository.GetByIdAsync(id);

                    if (reservation is null)
                    {
                        return ApiResponse<ReservationResponseDto<ReservationTicketResponseDto>>.Failed("Reservation not found", StatusCodes.Status404NotFound, []);
                    }

                    var currentUserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    if (string.IsNullOrEmpty(currentUserId))
                    {
                        return ApiResponse<ReservationResponseDto<ReservationTicketResponseDto>>.Failed("Unauthorized", StatusCodes.Status401Unauthorized, []);
                    }

                    var isOperator = _httpContextAccessor.HttpContext.User.IsInRole("Operator");
                    if (!reservation.UserId.ToString().Equals(currentUserId, StringComparison.OrdinalIgnoreCase) && !isOperator)
                    {
                        return ApiResponse<ReservationResponseDto<ReservationTicketResponseDto>>.Failed("Access denied", StatusCodes.Status403Forbidden, []);
                    }

                    var tickets = await _ticketRepository.GetAllAsync(t => t.ReservationId == reservation.Id);
                    //var ticketList = new List<ReservationTicketResponseDto>();

                    // Map tickets to ReservationTicketResponseDto
                    var mappedTickets = new List<ReservationTicketResponseDto>();

                    foreach (var ticket in tickets)
                    {
                        var play = await _playRepository.GetByIdAsync(ticket.PlayId);

                        var seat = await _seatRepository.GetByIdAsync(ticket.SeatId);

                        // Map to DTO
                        var ticketDto = new ReservationTicketResponseDto
                        {
                            Title = play!.Title,
                            SeatNumber = seat.SeatNumber,
                            SeatPrice = seat.Price,
                            ImageUrl = play.ImageUrl,
                            PlayPrice = play.Price,
                            FirstName = ticket.FirstName,
                            LastName = ticket.LastName,
                            DateOfBirth = ticket.DateOfBirth,
                            HasCheckedIn = ticket.HasCheckedIn || false,
                            TicketCode = ticket.TicketCode ?? "",
                        };

                        mappedTickets.Add(ticketDto);
                    }

                    // Construct the response DTO
                    var reservationResponse = new ReservationResponseDto<ReservationTicketResponseDto>
                    {
                        FirstName = reservation.FirstName,
                        LastName = reservation.LastName,
                        Email = reservation.Email,
                        UserId = reservation.UserId,
                        HasPaid = reservation.HasPaid,
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

        public async Task<ApiResponse<ReservationResponseDto<TicketResponseDto>>> MarkReservationAsPaidAsync(string id, UpdateReservationDto updateReservationDto)
        {
            try
            {
                using (Operation.Time("Time taken to update a reservation HasPaid property"))
                {
                    var reservation = await _reservationRepository.GetByIdAsync(id);
                    if (reservation is null)
                    {
                        return ApiResponse<ReservationResponseDto<TicketResponseDto>>.Failed("Reservation not found", StatusCodes.Status404NotFound, []);
                    }

                    reservation.HasPaid = updateReservationDto.HasPaid;
                    reservation.UpdatedAt = DateTimeOffset.UtcNow;
                    await _reservationRepository.SaveChangesAsync();

                    var reservationResponse = new ReservationResponseDto<TicketResponseDto>
                    {
                        FirstName = reservation.FirstName,
                        LastName = reservation.LastName,
                        Email = reservation.Email,
                        HasPaid = reservation.HasPaid,
                    };

                    return ApiResponse<ReservationResponseDto<TicketResponseDto>>.Success("Reservation retrieved succcessfully", StatusCodes.Status200OK, reservationResponse);

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some error occurred while retrieving reservation." + ex.Message);
                return ApiResponse<ReservationResponseDto<TicketResponseDto>>.Failed("Some error occurred while retrieving reservation." + ex.Message, StatusCodes.Status500InternalServerError, new List<string>() { ex.Message });
            }
        }

        private string GenerateTicketCode(int length = 5)
        {
            const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            StringBuilder result = new(length);

            for (int i = 0; i < length; i++)
            {
                result.Append(Chars[Random.Shared.Next(Chars.Length)]);
            }

            return $"GCT_{result?.ToString()}";
        }
    }
}
