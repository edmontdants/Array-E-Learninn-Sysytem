using ArrayELearnApi.Domain.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArrayELearnApi.Infrastructure.Configurations
{
    internal sealed class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasKey(n => n.ID);

            builder.Property(n => n.Content)
                   .IsRequired()
                   .HasMaxLength(1000);

            builder.Property(n => n.CreatedAt)
                   .HasDefaultValueSql("GETDATE()");
            
            builder.Property(n => n.CREATIONDATE)
                   .HasDefaultValueSql("GETDATE()");

            builder.Property(n => n.IsRead)
                   .HasDefaultValue(false);

            builder.HasOne(n => n.User)
                   .WithMany(u => u.Notifications)
                   .HasForeignKey(n => n.UserID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(n => new { n.UserID, n.IsRead, n.CreatedAt });
            // Performance indexes
            builder.HasIndex(n => n.UserID);          // Fast lookup by user
            builder.HasIndex(n => new { n.UserID, n.IsRead }); // Fast unread check
            builder.HasIndex(n => n.CreatedAt);       // Fast ordering by time
        }
    }
}
