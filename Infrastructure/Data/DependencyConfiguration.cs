using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Infrastructure.Data
{
   public static class RelationshipConfiguration
{
    public static void Map(ModelBuilder modelBuilder)
    {
      
        modelBuilder.Entity<User>()
            .HasOne(u => u.Profile)
            .WithOne(p => p.User)
            .HasForeignKey<Profile>(p => p.UserId)
            .IsRequired();

     
        modelBuilder.Entity<Session>()
            .HasOne(s => s.User)
            .WithMany(u => u.Sessions)
            .HasForeignKey(s => s.UserId);


        modelBuilder.Entity<AuditLog>()
            .HasOne(a => a.User)
            .WithMany(u => u.AuditLogs)
            .HasForeignKey(a => a.UserId);

        modelBuilder.Entity<PasswordRecovery>()
            .HasOne(pr => pr.User)
            .WithMany(u => u.PasswordRecovery)
            .HasForeignKey(pr => pr.UserId);

        
        modelBuilder.Entity<UserRole>()
            .HasKey(ur => new { ur.RoleId, ur.UserId });

        modelBuilder.Entity<UserRole>()
            .HasOne(ur => ur.User)
            .WithMany(u => u.UserRoles)
            .HasForeignKey(ur => ur.UserId);

        modelBuilder.Entity<UserRole>()
            .HasOne(ur => ur.Role)
            .WithMany(r => r.UserRole)
            .HasForeignKey(ur => ur.RoleId);

        modelBuilder.Entity<RolePermission>()
            .HasKey(rp => new { rp.RoleId, rp.PermissionId });

        modelBuilder.Entity<RolePermission>()
            .HasOne(rp => rp.Role)
            .WithMany(r => r.RolePermission)
            .HasForeignKey(rp => rp.RoleId);

        modelBuilder.Entity<RolePermission>()
            .HasOne(rp => rp.Permission)
            .WithMany(p => p.RolePermission)
            .HasForeignKey(rp => rp.PermissionId);

        modelBuilder.Entity<Route>()
            .HasOne(r => r.User)
            .WithMany(u => u.Routes)
            .HasForeignKey(r => r.Id);

        modelBuilder.Entity<TravelHistory>()
            .HasOne(th => th.User)
            .WithMany(u => u.TravelHistories)
            .HasForeignKey(th => th.Id);

        modelBuilder.Entity<TravelHistory>()
            .HasOne(th => th.Route)
            .WithMany(r => r.TravelHistories)
            .HasForeignKey(th => th.RouteId);

      
        modelBuilder.Entity<PointOfInterest>()
            .HasOne(p => p.User)
            .WithMany(u => u.PointOfInterest)
            .HasForeignKey(p => p.Id);

      
        modelBuilder.Entity<ObstacleReport>()
            .HasOne(o => o.User)
            .WithMany(u => u.ObstacleReports)
            .HasForeignKey(o => o.Id);

     
        modelBuilder.Entity<ReportValidation>()
            .HasKey(rv => new { rv.Id, rv.ReportId });

        modelBuilder.Entity<ReportValidation>()
            .HasOne(rv => rv.User)
            .WithMany(u => u.ReportValidations)
            .HasForeignKey(rv => rv.UserId);

        modelBuilder.Entity<ReportValidation>()
            .HasOne(rv => rv.ObstacleReport)
            .WithMany(o => o.Validations)
            .HasForeignKey(rv => rv.ReportId);


        modelBuilder.Entity<SupportTicket>()
            .HasOne(st => st.User)
            .WithMany(u => u.SupportTickets)
            .HasForeignKey(st => st.UserId);
    }
}
}