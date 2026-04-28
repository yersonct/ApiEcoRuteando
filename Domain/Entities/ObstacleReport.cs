using Api.Domain.Enums;
using Api.Domain.Enums.genery;
using Api.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Api.Domain.Entities
{
    public class ObstacleReport : EntityGenery
    {

        public int UserId { get; set; }
        public User User { get; set; }

        public ObstacleType ObstacleType { get; set; }
        public string Description { get; set; }

        public Coordinates Location { get; set; }
        public UrlImagen PhotoUrl { get; set; }

        public ReportStatus Status { get; set; } = ReportStatus.Pending;

        public DateTime CreatedAt { get; private set; } 

        public ICollection<ReportValidation> Validations { get; set; } = new List<ReportValidation>();

        public bool Active { get; set; } = true;
    }
}