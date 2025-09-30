using ArrayELearnApi.Domain.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArrayELearnApi.Infrastructure.Configurations
{
    internal sealed class NotificationArchiveConfiguration : IEntityTypeConfiguration<NotificationArchive>
    {
        public void Configure(EntityTypeBuilder<NotificationArchive> builder)
        {
            builder.HasKey(n => n.ID);

            builder.Property(n => n.ArchivedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(n => n.CREATIONDATE).HasDefaultValueSql("GETDATE()");

            builder.Property(n => n.Content).IsRequired().HasMaxLength(1000);

            builder.HasOne(n => n.Recipient)
                   .WithMany()
                   .HasForeignKey(n => n.RecipientID)
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
