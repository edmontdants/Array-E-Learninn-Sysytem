using ArrayELearnApi.Domain.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArrayELearnApi.Infrastructure.Configurations
{
    internal sealed class CourseTagConfiguration : IEntityTypeConfiguration<CourseTag>
    {
        public void Configure(EntityTypeBuilder<CourseTag> builder)
        {
            // Optional: configure composite PK for join table
            //builder.HasKey(ct => new { ct.CourseID, ct.TagID });
            //builder.Ignore(ct => ct.ID);
            builder.HasKey(ct => ct.ID);

            builder.Property(ct => ct.CREATIONDATE).HasDefaultValueSql("GETDATE()");

            builder.HasOne(ct => ct.Course)
                   .WithMany(c => c.CourseTags)
                   .HasForeignKey(ct => ct.CourseID)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ct => ct.Tag)
                   .WithMany(t => t.CourseTags)
                   .HasForeignKey(ct => ct.TagID)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ct => ct.Status)
                   .WithMany()
                   .HasForeignKey(ct => ct.StatusID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ct => ct.CREATEDBYUSER)
                   .WithMany()
                   .HasForeignKey(ct => ct.CREATEDBY)
                   .OnDelete(DeleteBehavior.Restrict); // or .SetNull

            builder.HasOne(ct => ct.MODIFIEDBYUSER)
                   .WithMany()
                   .HasForeignKey(ct => ct.MODIFIEDBY)
                   .OnDelete(DeleteBehavior.Restrict); // or .SetNull
        }
    }
}
