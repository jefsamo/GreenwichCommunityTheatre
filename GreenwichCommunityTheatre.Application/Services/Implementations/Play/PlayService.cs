using AutoMapper;
using GreenwichCommunityTheatre.Application.DTOs.Auth;
using GreenwichCommunityTheatre.Application.DTOs.Play;
using GreenwichCommunityTheatre.Application.Services.Implementations.Auth;
using GreenwichCommunityTheatre.Application.Services.Interfaces.Play;
using GreenwichCommunityTheatre.Domain;
using GreenwichCommunityTheatre.Domain.Entities;
using GreenwichCommunityTheatre.Infrastructure.Context;
using GreenwichCommunityTheatre.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SerilogTimings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenwichCommunityTheatre.Application.Services.Implementations.Play
{
    public class PlayService : IPlayService
    {
        private readonly IMapper _mapper;
        private readonly GctDbContext _gctDbContext;
        private readonly ILogger<PlayService> _logger;
        private readonly IGenericRepository<GreenwichCommunityTheatre.Domain.Entities.Play> _playRepository;

        public PlayService(IMapper mapper, GctDbContext gctDbContext, ILogger<PlayService> logger, IGenericRepository<GreenwichCommunityTheatre.Domain.Entities.Play> playRepository)
        {
            _gctDbContext = gctDbContext;
            _mapper = mapper;
            _logger = logger;
            _playRepository = playRepository;
        }

        public async Task<ApiResponse<PlayResponseDto>> CreatePlayAsync(CreatePlayDto createPlayDto)
        {
            try
            {
                using (Operation.Time("Time taken to create a play"))
                {
                    var play = _mapper.Map<GreenwichCommunityTheatre.Domain.Entities.Play>(createPlayDto);
                    play.AvailableSeats = createPlayDto.TotalSeats;

                    await _playRepository.AddAsync(play);
                    await _gctDbContext.SaveChangesAsync();

                    var playDto = _mapper.Map<PlayResponseDto>(play);
                    return ApiResponse<PlayResponseDto>.Success("Play created succcessfully", StatusCodes.Status201Created, playDto);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some error occurred while creating play." + ex.Message);
                return ApiResponse<PlayResponseDto>.Failed("Some error occurred while creating play." + ex.Message, StatusCodes.Status500InternalServerError, new List<string>() { ex.Message });
            }
        }

        public async Task<ApiResponse<PlayResponseDto>> DeletePlayAsync(string id)
        {
            try
            {
                using (Operation.Time("Time taken to update a play"))
                {
                    var play = await _playRepository.GetByIdAsync(id);

                    if (play is null)
                    {
                        return ApiResponse<PlayResponseDto>.Failed("Play not found", StatusCodes.Status404NotFound, []);
                    }

                    _playRepository.DeleteAsync(play);
                    await _playRepository.SaveChangesAsync();

                    var playDto = _mapper.Map<PlayResponseDto>(play);
                    return ApiResponse<PlayResponseDto>.Success("Play deleted succcessfully", StatusCodes.Status200OK, playDto);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some error occurred while deleting play." + ex.Message);
                return ApiResponse<PlayResponseDto>.Failed("Some error occurred while deleting play." + ex.Message, StatusCodes.Status500InternalServerError, new List<string>() { ex.Message });
            }
        }

        public async Task<ApiResponse<IEnumerable<PlayResponseDto>>> GetAllPlayAsync()
        {
            try
            {
                using (Operation.Time("Time taken to get all plays"))
                {
                    var plays = await _playRepository.GetAllAsync();

                    var playsDto = _mapper.Map<IEnumerable<PlayResponseDto>>(plays);
                    return ApiResponse<IEnumerable<PlayResponseDto>>.Success("All plays retrieved succcessfully", StatusCodes.Status201Created, playsDto);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some error occurred while retrieving plays." + ex.Message);
                return ApiResponse<IEnumerable<PlayResponseDto>>.Failed("Some error occurred while retrieving plays." + ex.Message, StatusCodes.Status500InternalServerError, new List<string>() { ex.Message });
            }
        }
        public async Task<ApiResponse<PlayResponseDto>> GetPlayAsync(string id)
        {
            try
            {
                using (Operation.Time("Time taken to get a play"))
                {
                    var play = await _playRepository.GetByIdAsync(id);

                    if (play is null)
                    {
                        return ApiResponse<PlayResponseDto>.Failed("Play not found", StatusCodes.Status404NotFound, []);
                    }

                    var playDto = _mapper.Map<PlayResponseDto>(play);
                    return ApiResponse<PlayResponseDto>.Success("Play retrieved succcessfully", StatusCodes.Status200OK, playDto);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some error occurred while retrieving play." + ex.Message);
                return ApiResponse<PlayResponseDto>.Failed("Some error occurred while retrieving play." + ex.Message, StatusCodes.Status500InternalServerError, new List<string>() { ex.Message });
            }
        }

        public async Task<ApiResponse<PlayResponseDto>> UpdatePlayAsync(string id, UpdatePlayDto updatePlayDto)
        {
            try
            {
                using (Operation.Time("Time taken to update a play"))
                {
                    var play = await _playRepository.GetByIdAsync(id);

                    if (play is null)
                    {
                        return ApiResponse<PlayResponseDto>.Failed("Play not found", StatusCodes.Status404NotFound, []);
                    }
                    _mapper.Map(updatePlayDto, play);

                    play.UpdatedAt = DateTimeOffset.Now;
                   
                    await _playRepository.SaveChangesAsync();

                    var playDto = _mapper.Map<PlayResponseDto>(play);
                    return ApiResponse<PlayResponseDto>.Success("Play updated succcessfully", StatusCodes.Status200OK, playDto);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some error occurred while updating play." + ex.Message);
                return ApiResponse<PlayResponseDto>.Failed("Some error occurred while updating play." + ex.Message, StatusCodes.Status500InternalServerError, new List<string>() { ex.Message });
            }
        }
    }
}
