using ArrayELearnApi.Domain.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArrayELearnApi.Infrastructure.Configurations
{
    internal sealed class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.ID);

            builder.Property(s => s.UserID).IsRequired().HasMaxLength(450);
            builder.HasIndex(s => s.UserID).IsUnique();

            builder.Property(e => e.CREATIONDATE).HasDefaultValueSql("GETDATE()");

            builder.HasOne(s => s.User)
                   .WithOne(u => u.Student)
                   .HasForeignKey<Student>(s => s.UserID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(s => s.Enrollments)
                   .WithOne(e => e.Student)
                   .HasForeignKey(e => e.StudentID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(s => s.Submissions)
                   .WithOne(e => e.Student)
                   .HasForeignKey(e => e.StudentID)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
