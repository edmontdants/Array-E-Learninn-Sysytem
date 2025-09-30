using ArrayELearnApi.Domain.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArrayELearnApi.Infrastructure.Configurations
{
    internal sealed class AttendanceConfiguration : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            // Key
            builder.HasKey(a => a.ID);
            builder.HasIndex(a => new { a.StudentID, a.CourseId, a.Date }).IsUnique(); // one record/day

            // Properties
            builder.Property(a => a.Date).IsRequired();
            builder.Property(a => a.IsPresent).IsRequired();
            builder.Property(a => a.CREATIONDATE).HasDefaultValueSql("GETDATE()");

            // Relationships
            builder.HasOne(a => a.Student)
                   .WithMany(s => s.Attendances)
                   .HasForeignKey(a => a.StudentID)
                   .OnDelete(DeleteBehavior.Restrict); // safer than Cascade to avoid accidental user deletion

            builder.HasOne(a => a.Course)
                   .WithMany(c => c.Attendances)
                   .HasForeignKey(a => a.CourseId)
                   .OnDelete(DeleteBehavior.Cascade); // deleting a course should delete attendances

            builder.HasOne(a => a.Status)
                   .WithMany()
                   .HasForeignKey(a => a.StatusID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.CREATEDBYUSER)
                   .WithMany()
                   .HasForeignKey(a => a.CREATEDBY)
                   .OnDelete(DeleteBehavior.Restrict); // or .SetNull

            builder.HasOne(a => a.MODIFIEDBYUSER)
                   .WithMany()
                   .HasForeignKey(a => a.MODIFIEDBY)
                   .OnDelete(DeleteBehavior.Restrict); // or .SetNull
        }
    }
}
