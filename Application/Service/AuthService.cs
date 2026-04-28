using Api.Domain.Interface;
using System;

namespace Api.Application.Service
{
    public class AuthService
    {
        private readonly ITokenService _tokenService;

        public AuthService(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public string Login(int userId, string email)
        {
            var tokenId = Guid.NewGuid().ToString();

            var token = _tokenService.GenerateToken(userId, email, tokenId);


            return token;
        }
    }
}
