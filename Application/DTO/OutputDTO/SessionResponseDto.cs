using System;

namespace Api.Application.DTO.OutputDTO
{
    public class SessionResponseDto
    {
        public string Email { get; set; }
        public string TokenId { get; set; }
        public string IpAddress { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
    }

}