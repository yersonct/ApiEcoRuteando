namespace Api.Domain.Interface
{
    public interface ITokenService
    {
        string GenerateToken(int userId, string email, string tokenId);
    }
}
