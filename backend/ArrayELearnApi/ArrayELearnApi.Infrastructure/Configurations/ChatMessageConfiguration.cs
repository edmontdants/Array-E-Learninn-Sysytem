using ArrayELearnApi.Domain.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArrayELearnApi.Infrastructure.Configurations
{
    internal sealed class ChatMessageConfiguration : IEntityTypeConfiguration<ChatMessage>
    {
        public void Configure(EntityTypeBuilder<ChatMessage> builder)
        {
            builder.HasKey(m => m.ID);
            // Performance indexes
            builder.HasIndex(m => new { m.SenderID, m.ReceiverID, m.SentAt }); // conversation lookup
            builder.HasIndex(m => m.ReceiverID);       // unread fetch
            builder.HasIndex(m => m.IsRead);           // filter quickly

            builder.Property(m => m.Message).IsRequired().HasMaxLength(4000); // Limit size for performance
            builder.Property(m => m.SentAt).HasDefaultValueSql("GETDATE()");
            builder.Property(m => m.CREATIONDATE).HasDefaultValueSql("GETDATE()");


            // Relationships
            builder.HasOne(m => m.Sender)
                   .WithMany()
                   .HasForeignKey(m => m.SenderID)
                   .OnDelete(DeleteBehavior.Restrict); // don’t delete old messages if user deleted

            builder.HasOne(m => m.Receiver)
                   .WithMany()
                   .HasForeignKey(m => m.ReceiverID)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
