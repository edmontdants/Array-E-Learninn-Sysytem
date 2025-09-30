using ArrayELearnApi.Domain.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArrayELearnApi.Infrastructure.Configurations
{
    internal sealed class LessonConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.HasKey(l => l.ID);

            builder.Property(l => l.CREATIONDATE).HasDefaultValueSql("GETDATE()");

            builder.HasOne(l => l.Status)
                   .WithMany()
                   .HasForeignKey(l => l.StatusID)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
