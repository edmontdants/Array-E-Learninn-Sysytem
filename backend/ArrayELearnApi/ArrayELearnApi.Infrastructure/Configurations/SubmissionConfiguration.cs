using ArrayELearnApi.Domain.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArrayELearnApi.Infrastructure.Configurations
{
    internal sealed class SubmissionConfiguration : IEntityTypeConfiguration<Submission>
    {
        public void Configure(EntityTypeBuilder<Submission> builder)
        {
            builder.HasKey(s => s.ID);
            builder.HasIndex(s => new { s.AssignmentID, s.StudentID }).IsUnique(); // one submission per student per assignment

            builder.Property(s => s.FileUrl).IsRequired().HasMaxLength(500);
            //builder.Property(s => s.GradeValue);
            builder.Property(s => s.Feedback).HasMaxLength(2000);
            builder.Property(s => s.SubmittedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(s => s.CREATIONDATE).HasDefaultValueSql("GETDATE()");

            builder.HasOne(s => s.Assignment)
                   .WithMany(a => a.Submissions)
                   .HasForeignKey(s => s.AssignmentID)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(s => s.Student)
                   .WithMany(st => st.Submissions)
                   .HasForeignKey(s => s.StudentID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Grade)
                   .WithMany()
                   .HasForeignKey(s => s.GradeID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Status)
                   .WithMany()
                   .HasForeignKey(s => s.StatusID)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
