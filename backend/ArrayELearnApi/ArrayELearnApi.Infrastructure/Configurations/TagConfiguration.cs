using ArrayELearnApi.Domain.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArrayELearnApi.Infrastructure.Configurations
{
    internal sealed class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasKey(t => t.ID);
            builder.Property(t => t.CREATIONDATE).HasDefaultValueSql("GETDATE()");

            // Restrict delete from CourseTag side
            builder.HasMany(t => t.CourseTags)
                   .WithOne(ct => ct.Tag)
                   .HasForeignKey(ct => ct.TagID)
                   .OnDelete(DeleteBehavior.Restrict); // prevent CourseTag from deleting Tag
        }
    }
}
