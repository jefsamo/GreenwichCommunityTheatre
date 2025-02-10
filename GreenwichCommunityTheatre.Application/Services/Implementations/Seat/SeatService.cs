using AutoMapper;
using GreenwichCommunityTheatre.Application.DTOs.Seat;
using GreenwichCommunityTheatre.Application.Services.Interfaces.Seat;
using GreenwichCommunityTheatre.Domain;
using GreenwichCommunityTheatre.Infrastructure.Context;
using GreenwichCommunityTheatre.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SerilogTimings;

namespace GreenwichCommunityTheatre.Application.Services.Implementations.Seat
{
    public class SeatService : ISeatService
    {
        private readonly IMapper _mapper;
        private readonly GctDbContext _gctDbContext;
        private readonly ILogger<SeatService> _logger;
        private readonly IGenericRepository<GreenwichCommunityTheatre.Domain.Entities.Seat> _seatRepository;

        public SeatService(IMapper mapper, GctDbContext gctDbContext, ILogger<SeatService> logger, IGenericRepository<GreenwichCommunityTheatre.Domain.Entities.Seat> seatRepository)
        {
            _mapper = mapper;
            _gctDbContext = gctDbContext;
            _logger = logger;
            _seatRepository = seatRepository;
        }

        public async Task<ApiResponse<SeatResponseDto>> CreateSeatAsync(CreateSeatDto createSeatDto)
        {
            try
            {
                using (Operation.Time("Time taken to create a seat"))
                {
                    var seat = _mapper.Map<GreenwichCommunityTheatre.Domain.Entities.Seat>(createSeatDto);

                    await _seatRepository.AddAsync(seat);
                    await _gctDbContext.SaveChangesAsync();

                    var seatDto = _mapper.Map<SeatResponseDto>(seat);
                    return ApiResponse<SeatResponseDto>.Success("Seat created succcessfully", StatusCodes.Status201Created, seatDto);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some error occurred while creating play." + ex.Message);
                return ApiResponse<SeatResponseDto>.Failed("Some error occurred while creating seat." + ex.Message, StatusCodes.Status500InternalServerError, new List<string>() { ex.Message });
            }
        }

        public async Task<ApiResponse<IEnumerable<SeatResponseDto>>> GetAllSeatAsync()
        {
            try
            {
                using (Operation.Time("Time taken to get all seats"))
                {
                    var seats = await _seatRepository.GetAllAsync();

                    var seatsDto = _mapper.Map<IEnumerable<SeatResponseDto>>(seats);
                    return ApiResponse<IEnumerable<SeatResponseDto>>.Success("All seats retrieved succcessfully", StatusCodes.Status201Created, seatsDto);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some error occurred while retrieving seats." + ex.Message);
                return ApiResponse<IEnumerable<SeatResponseDto>>.Failed("Some error occurred while retrieving seats." + ex.Message, StatusCodes.Status500InternalServerError, new List<string>() { ex.Message });
            }
        }

        public async Task<ApiResponse<SeatResponseDto>> GetSeatAsync(string id)
        {
            try
            {
                using (Operation.Time("Time taken to get a seat"))
                {
                    var seat = await _seatRepository.GetByIdAsync(id);

                    if (seat is null)
                    {
                        return ApiResponse<SeatResponseDto>.Failed("Seat not found", StatusCodes.Status404NotFound, []);
                    }

                    var seatDto = _mapper.Map<SeatResponseDto>(seat);
                    return ApiResponse<SeatResponseDto>.Success("Seat retrieved succcessfully", StatusCodes.Status200OK, seatDto);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some error occurred while retrieving seat." + ex.Message);
                return ApiResponse<SeatResponseDto>.Failed("Some error occurred while retrieving seat." + ex.Message, StatusCodes.Status500InternalServerError, new List<string>() { ex.Message });
            }
        }

        public async Task<ApiResponse<SeatResponseDto>> UpdateSeatAsync(string id, UpdateSeatDto updateSeatDto)
        {
            try
            {
                using (Operation.Time("Time taken to update a seat"))
                {
                    var seat = await _seatRepository.GetByIdAsync(id);

                    if (seat is null)
                    {
                        return ApiResponse<SeatResponseDto>.Failed("Seat not found", StatusCodes.Status404NotFound, []);
                    }
                    _mapper.Map(updateSeatDto, seat);

                    seat.UpdatedAt = DateTimeOffset.Now;

                    await _seatRepository.SaveChangesAsync();

                    var seatDto = _mapper.Map<SeatResponseDto>(seat);
                    return ApiResponse<SeatResponseDto>.Success("Seat updated succcessfully", StatusCodes.Status200OK, seatDto);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some error occurred while updating seat." + ex.Message);
                return ApiResponse<SeatResponseDto>.Failed("Some error occurred while updating seat." + ex.Message, StatusCodes.Status500InternalServerError, new List<string>() { ex.Message });
            }
        }

        public async Task<ApiResponse<SeatResponseDto>> DeleteSeatAsync(string id)
        {
            try
            {
                using (Operation.Time("Time taken to delete a seat"))
                {
                    var seat = await _seatRepository.GetByIdAsync(id);

                    if (seat is null)
                    {
                        return ApiResponse<SeatResponseDto>.Failed("Seat not found", StatusCodes.Status404NotFound, []);
                    }

                    _seatRepository.DeleteAsync(seat);
                    await _seatRepository.SaveChangesAsync();

                    var seatDto = _mapper.Map<SeatResponseDto>(seat);
                    return ApiResponse<SeatResponseDto>.Success("Seat deleted succcessfully", StatusCodes.Status204NoContent, default!);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some error occurred while deleting play." + ex.Message);
                return ApiResponse<SeatResponseDto>.Failed("Some error occurred while deleting seat." + ex.Message, StatusCodes.Status500InternalServerError, new List<string>() { ex.Message });
            }
        }
    }
}
