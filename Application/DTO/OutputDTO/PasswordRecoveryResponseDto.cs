using System;

namespace Api.Application.DTO.OutputDTO
{
        public class PasswordRecoveryResponseDto
        {
            public int UserId { get; set; }
            public string Code { get; set; }
            public DateTime ExpirationDate { get; set; }
            public bool IsUsed { get; set; }
            public bool Active { get; set; }
        }
}