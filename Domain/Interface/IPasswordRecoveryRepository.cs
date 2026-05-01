using Api.Domain.Entities;
using System.Threading.Tasks;

namespace Api.Domain.Interface
{
    public interface IPasswordRecoveryRepository : IRepository<PasswordRecovery>
    {
        Task<PasswordRecovery> GetByEmailAndCode(string email, string code);
        Task AddAsync(PasswordRecovery entity);
        Task SaveChangesAsync();
    }
}