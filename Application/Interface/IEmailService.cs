using System.Threading.Tasks;

namespace Api.Domain.Interface
{
    public interface IEmailService
    {
        Task SendEmailAsync(string to, string subject, string body);
    }
}