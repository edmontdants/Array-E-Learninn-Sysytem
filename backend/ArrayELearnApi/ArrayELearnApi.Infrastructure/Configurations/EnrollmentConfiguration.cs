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

            builder.HasOne(a => a.Status)
                   .WithMany()
                   .HasForeignKey(a => a.StatusID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(e => new { e.StudentID, e.CourseID }).IsUnique(); // prevent double-enroll
        }
    }
}
