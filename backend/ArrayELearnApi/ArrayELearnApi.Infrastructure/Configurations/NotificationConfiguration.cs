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
            // Performance indexes
            //builder.HasIndex(n => new { n.RecipientID, n.IsRead, n.CreatedAt });
            builder.HasIndex(n => n.RecipientID);          // Fast lookup by user
            builder.HasIndex(n => new { n.RecipientID, n.IsRead }); // Fast unread check
            builder.HasIndex(n => n.CreatedAt);       // Fast ordering by time

            builder.Property(n => n.RecipientID).IsRequired().HasMaxLength(450);
            builder.Property(n => n.MessageID).IsRequired().HasMaxLength(450);
            builder.Property(n => n.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(n => n.CREATIONDATE).HasDefaultValueSql("GETDATE()");

            builder.HasOne(n => n.Recipient)
                   .WithMany(u => u.Notifications)
                   .HasForeignKey(n => n.RecipientID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(n => n.Message)
                   .WithMany(u => u.Notifications)
                   .HasForeignKey(n => n.MessageID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(n => n.CREATEDBYUSER)
                   .WithMany()
                   .HasForeignKey(n => n.CREATEDBY)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(n => n.MODIFIEDBYUSER)
                   .WithMany()
                   .HasForeignKey(n => n.MODIFIEDBY)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
