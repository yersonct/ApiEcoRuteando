using Api.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Api.Domain.Interface
{
    public interface IDailyStatisticsRepository : IRepository<DailyStatistics>
    {
        Task<DailyStatistics?> GetByDateAsync(DateTime date);
        Task AddAsync(DailyStatistics stats);
        Task UpdateAsync(DailyStatistics stats);
    }
}
