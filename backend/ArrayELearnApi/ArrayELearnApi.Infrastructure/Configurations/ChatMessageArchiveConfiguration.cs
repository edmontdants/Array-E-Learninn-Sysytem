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
            builder.HasKey(m => m.ID);

            builder.Property(m => m.Message).IsRequired().HasMaxLength(4000);
            builder.Property(m => m.ArchivedAt).HasDefaultValueSql("GETDATE()");
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
