using ArrayELearnApi.Domain.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArrayELearnApi.Infrastructure.Configurations
{
    internal sealed class NotificationMessageConfiguration : IEntityTypeConfiguration<NotificationMessage>
    {
        public void Configure(EntityTypeBuilder<NotificationMessage> builder)
        {
            builder.HasKey(m => m.ID);

            builder.Property(m => m.Content).IsRequired().HasMaxLength(1000);
            builder.Property(m => m.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(m => m.CREATIONDATE).HasDefaultValueSql("GETDATE()");

            builder.HasOne(m => m.CREATEDBYUSER)
                   .WithMany()  // no inverse navigation
                   .HasForeignKey(m => m.CREATEDBY)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(m => m.MODIFIEDBYUSER)
                   .WithMany()  // no inverse navigation
                   .HasForeignKey(m => m.MODIFIEDBY)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
