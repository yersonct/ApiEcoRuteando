using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infrastructure.Data.Configurations
{
    public class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.IpAddress, ip =>
            {
                ip.Property(x => x.Value)
                  .HasColumnName("IpAddress")
                  .IsRequired();
            });

            builder.Property(x => x.CreatedAt)
                   .HasColumnName("StartDate")
                   .IsRequired();

            builder.Property(x => x.ExpiresAt)
                    .HasColumnName("ExpiresAt")
                    .IsRequired();

            builder.Property(x => x.UserId)
                   .HasColumnName("UserId")
                   .IsRequired();

            builder.Property(x => x.Active)
                   .HasColumnName("Active")
                   .IsRequired();
        }
    }
}