using ArrayELearnApi.Domain.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArrayELearnApi.Infrastructure.Configurations
{
    internal sealed class SupportTicketConfiguration : IEntityTypeConfiguration<SupportTicket>
    {
        public void Configure(EntityTypeBuilder<SupportTicket> builder)
        {
            builder.HasKey(t => t.ID);

            builder.Property(t => t.Subject).IsRequired().HasMaxLength(200);
            builder.Property(t => t.Message).IsRequired().HasMaxLength(4000);
            builder.Property(t => t.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(e => e.CREATIONDATE).HasDefaultValueSql("GETDATE()");

            builder.HasOne(t => t.User)
                   .WithMany(u => u.SupportTickets)
                   .HasForeignKey(t => t.UserID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(t => new { t.UserID, t.CreatedAt });
        }
    }
}
