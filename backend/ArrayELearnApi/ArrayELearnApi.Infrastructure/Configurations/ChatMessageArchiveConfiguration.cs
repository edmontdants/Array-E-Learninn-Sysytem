using ArrayELearnApi.Domain.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArrayELearnApi.Infrastructure.Configurations
{
    internal sealed class ChatMessageArchiveConfiguration : IEntityTypeConfiguration<ChatMessageArchive>
    {
        public void Configure(EntityTypeBuilder<ChatMessageArchive> builder)
        {
            // Keys & indexes
            builder.HasKey(u => u.ID);

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
