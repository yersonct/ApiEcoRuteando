using Api.Domain.Entities;
using Api.Domain.Interface;
using Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Infrastructure.Repositories
{
    public class DailyStatisticsRepository : IDailyStatisticsRepository
    {
        private readonly AppDbContext _context;

        public DailyStatisticsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<DailyStatistics?> GetByDateAsync(DateTime date)
        {
            return await _context.Set<DailyStatistics>()
                .FirstOrDefaultAsync(x => x.ReportDate.Date == date.Date);
        }

        public async Task AddAsync(DailyStatistics stats)
        {
            await _context.Set<DailyStatistics>().AddAsync(stats);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DailyStatistics stats)
        {
            _context.Set<DailyStatistics>().Update(stats);
            await _context.SaveChangesAsync();
        }

        // 🔥 IMPLEMENTADOS

        public async Task<List<DailyStatistics>> GetAllAsync()
        {
            return await _context.Set<DailyStatistics>().ToListAsync();
        }

        public async Task<DailyStatistics?> GetByIdAsync(int id)
        {
            return await _context.Set<DailyStatistics>().FindAsync(id);
        }

        public async Task CreateAsync(DailyStatistics entity)
        {
            await _context.Set<DailyStatistics>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<DailyStatistics>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<DailyStatistics>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}