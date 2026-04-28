using Api.Domain.Enums.genery;
using Api.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Entities
{
    public class User : EntityGenery
    {
        public Username Name { get; set; }
        public string LastName { get; set; }
        public Password Password { get; set; }
        public Email Email { get; set; }

        public Configuration Configuration { get; set; }

        public Profile Profile { get; set; }

        public ICollection<Session> Sessions { get; set; } 

        public ICollection<UserRole> UserRoles { get; set; }

        public ICollection<AuditLog> AuditLogs { get; set; }
        public ICollection<PasswordRecovery> PasswordRecoveries { get; set; } 
        public ICollection<SupportTicket> SupportTickets { get; set; }

        public ICollection<ReportValidation> ReportValidations { get; set; }
        public ICollection<ObstacleReport> ObstacleReports { get; set; }

        public ICollection<PointOfInterest> PointOfInterest { get; set; }

        public ICollection<PasswordRecovery> PasswordRecovery { get; set; }
        public ICollection<TravelHistory> TravelHistories { get; set; }

        public ICollection<Route> Routes { get; set; }

        public bool Active { get; set; } = true;
    }
}
