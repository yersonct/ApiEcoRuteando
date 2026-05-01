using Api.Domain.Interface;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api.Infrastructure.Repositories
{
    public class TokenService : ITokenService
    {
        public string GenerateToken(int userId, string email, string tokenId)
        {
            var claims = new[]
            {
            new Claim("sub", userId.ToString()),
            new Claim("email", email),
            new Claim("jti", tokenId)
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("TU_SECRET"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "tuApp",
                audience: "tuApp",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
