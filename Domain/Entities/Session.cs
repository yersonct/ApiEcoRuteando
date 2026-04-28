using Api.Domain.Enums.genery;
using Api.Domain.ValueObjects;
using System;

namespace Api.Domain.Entities
{
    public class Session : EntityGenery
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public string TokenId { get; set; }

        public IpAddress IpAddress { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime ExpiresAt { get; set; }

        public bool Active { get; set; } = true;
    }
}