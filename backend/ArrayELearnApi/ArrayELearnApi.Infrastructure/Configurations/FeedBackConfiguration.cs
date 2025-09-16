using ArrayELearnApi.Domain.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArrayELearnApi.Infrastructure.Configurations
{
    internal sealed class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.HasKey(f => f.ID);

            builder.Property(f => f.Description).HasMaxLength(1000);
            builder.Property(f => f.CREATIONDATE).HasDefaultValueSql("GETDATE()");

            builder.HasOne(f => f.Status)
                   .WithMany()
                   .HasForeignKey(f => f.StatusID)
                   .OnDelete(DeleteBehavior.Restrict); // prevents cascade

            builder.HasOne(f => f.Student)
                   .WithMany()
                   .HasForeignKey(f => f.ID)
                   .OnDelete(DeleteBehavior.Restrict); // prevents cascade
        }
    }
}
