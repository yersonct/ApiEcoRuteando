using Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Domain.Interface
{
    public interface ITravelHistoryRepository : IRepository<TravelHistory>
    {
        Task<List<TravelHistory>> GetByDateAsync(DateTime date);
    }
}