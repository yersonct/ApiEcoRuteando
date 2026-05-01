using Api.Application.DTO.InputDTO;
using Api.Application.DTO.OutputDTO;
using Api.Domain.Entities;
using Api.Domain.Interface;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Application.Service
{
    public class DailyStatisticsService
    {
        private readonly IDailyStatisticsRepository _statisticsRepository;
        private readonly ITravelHistoryRepository _travelHistoryRepository;
        private readonly IMapper _mapper;

        public DailyStatisticsService(
            IDailyStatisticsRepository statisticsRepository,
            ITravelHistoryRepository travelHistoryRepository,
            IMapper mapper)
        {
            _statisticsRepository = statisticsRepository;
            _travelHistoryRepository = travelHistoryRepository;
            _mapper = mapper;
        }

        public async Task<List<TravelHistory>> GetByDateAsync(DateTime date)
        {
            return await _travelHistoryRepository.GetByDateAsync(date);
        }
        public async Task<List<DailyStatisticsResponseDto>> GetAll()
        {
            var list = await _statisticsRepository.GetAllAsync();
            return _mapper.Map<List<DailyStatisticsResponseDto>>(list);
        }

        public async Task<DailyStatisticsResponseDto?> GetByDate(DateTime date)
        {
            var result = await _statisticsRepository.GetByDateAsync(date);

            if (result == null)
                return null;

            return _mapper.Map<DailyStatisticsResponseDto>(result);
        }
    }
}