using ArrayELearnApi.Domain.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArrayELearnApi.Infrastructure.Configurations
{
    internal sealed class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.HasKey(e => e.ID);
            builder.HasIndex(e => new { e.StudentID, e.CourseID }).IsUnique(); // prevent double-enroll

            builder.Property(e => e.EnrolledAt).HasDefaultValueSql("GETDATE()");
            builder.Property(e => e.CREATIONDATE).HasDefaultValueSql("GETDATE()");

            builder.HasOne(e => e.Student)
                   .WithMany(s => s.Enrollments)
                   .HasForeignKey(e => e.StudentID)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Course)
                   .WithMany(c => c.Enrollments)
                   .HasForeignKey(e => e.CourseID)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Status)
                   .WithMany()
                   .HasForeignKey(e => e.StatusID)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
