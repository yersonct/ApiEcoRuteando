using Api.Domain.Entities;
using Api.Domain.Interface;
using Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Api.Infrastructure.Repositories
{
    public class PasswordRecoveryRepository : Repository<PasswordRecovery>, IPasswordRecoveryRepository
    {
        private readonly AppDbContext _context;

        public PasswordRecoveryRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task AddAsync(PasswordRecovery entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task<PasswordRecovery> GetByEmailAndCode(string email, string code)
        {
            return await _dbSet
                .Include(x => x.User)
                .FirstOrDefaultAsync(x =>
                    x.User.Email.Value == email &&
                    x.TemporaryCode.Value == code);
        }
    }
}