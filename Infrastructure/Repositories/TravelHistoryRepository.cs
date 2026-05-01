using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Api.Domain.Entities;
using Api.Domain.Interface;
using Api.Infrastructure.Data;

namespace Api.Infrastructure.Repositories
{
    public class TravelHistoryRepository : Repository<TravelHistory>, ITravelHistoryRepository
    {
        public TravelHistoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<TravelHistory>> GetByDateAsync(DateTime date)
        {
            return await _dbSet.ToListAsync();
        }
    }
}