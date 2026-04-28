using Api.Domain.Enums;
using Api.Domain.Enums.genery;
using System;
using System.Collections.Generic;

namespace Api.Domain.Entities
{
    public class Configuration : EntityGenery
    {
        public int UserId { get; set; }

        public User User { get; set; }
        public Language Language { get; set; }
        public Theme BackgroundColor { get; set; }

        public bool IsVoiceActive { get; set; }

        public bool Active { get; set; } = true;

    }
}