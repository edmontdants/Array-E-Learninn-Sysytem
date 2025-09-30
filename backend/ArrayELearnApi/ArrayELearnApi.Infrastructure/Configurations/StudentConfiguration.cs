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
            builder.HasIndex(s => s.UserID).IsUnique();

            builder.Property(s => s.UserID).IsRequired().HasMaxLength(450);
            builder.Property(s => s.CREATIONDATE).HasDefaultValueSql("GETDATE()");

            builder.HasOne(s => s.User)
                   .WithMany(u => u.Students)
                   .HasForeignKey(s => s.UserID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(s => s.Enrollments)
                   .WithOne(e => e.Student)
                   .HasForeignKey(e => e.StudentID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(s => s.Submissions)
                   .WithOne(s => s.Student)
                   .HasForeignKey(s => s.StudentID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.CREATEDBYUSER)
                   .WithMany()
                   .HasForeignKey(s => s.CREATEDBY)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.MODIFIEDBYUSER)
                   .WithMany()
                   .HasForeignKey(s => s.MODIFIEDBY)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
