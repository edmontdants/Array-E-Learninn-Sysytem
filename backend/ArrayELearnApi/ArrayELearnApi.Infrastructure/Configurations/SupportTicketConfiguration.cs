using ArrayELearnApi.Domain.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArrayELearnApi.Infrastructure.Configurations
{
    internal sealed class SupportTicketConfiguration : IEntityTypeConfiguration<SupportTicket>
    {
        public void Configure(EntityTypeBuilder<SupportTicket> builder)
        {
            builder.HasKey(st => st.ID);
            builder.HasIndex(st => new { st.UserID, st.CreatedAt });

            builder.Property(st=> st.Subject).IsRequired().HasMaxLength(200);
            builder.Property(st=> st.Message).HasMaxLength(2000);
            builder.Property(st=> st.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(st => st.CREATIONDATE).HasDefaultValueSql("GETDATE()");

            builder.HasOne(st => st.User)
                   .WithMany(u => u.SupportTickets)
                   .HasForeignKey(st => st.UserID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(st => st.CREATEDBYUSER)
                   .WithMany()
                   .HasForeignKey(st => st.CREATEDBY)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(st => st.MODIFIEDBYUSER)
                   .WithMany()
                   .HasForeignKey(st => st.MODIFIEDBY)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
