using ArrayELearnApi.Domain.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArrayELearnApi.Infrastructure.Configurations
{
    internal sealed class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.ID);
            builder.HasIndex(c => c.Code).IsUnique();

            builder.Property(c => c.Code).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Title).IsRequired().HasMaxLength(200);
            builder.Property(c => c.Description).HasMaxLength(4000);
            builder.Property(c => c.Price).HasColumnType("decimal(18,2)");
            builder.Property(c => c.ThumbnailUrl).HasMaxLength(500);
            builder.Property(c => c.Level).HasMaxLength(50);
            builder.Property(c => c.Duration).HasMaxLength(100);
            builder.Property(c => c.Prerequisites).HasMaxLength(2000);
            builder.Property(c => c.TargetAudience).HasMaxLength(1000);
            builder.Property(c => c.CourseUrl).HasMaxLength(500);
            builder.Property(c => c.Syllabus).HasColumnType("nvarchar(max)");
            builder.Property(c => c.LastUpdated).HasDefaultValueSql("GETDATE()");
            builder.Property(c => c.CREATIONDATE).HasDefaultValueSql("GETDATE()");

            //builder.Property(c => c.Language)  // consider enum + HasConversion<int>()
            //       .HasConversion<int>()  // store enum as int
            //       .IsRequired();

            //builder.Property(u => u.Gender)
            //    .HasConversion<int>() // store enum as int
            //    .IsRequired();

            builder.HasOne(c => c.Language)
                   .WithMany()
                   .HasForeignKey(c => c.LanguageID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.Enrollments)
                   .WithOne(e => e.Course)
                   .HasForeignKey(e => e.CourseID)
                   .OnDelete(DeleteBehavior.Restrict);

            // Restrict delete from CourseTag side
            builder.HasMany(c => c.CourseTags)
                   .WithOne(ct => ct.Course)
                   .HasForeignKey(ct => ct.CourseID)
                   .OnDelete(DeleteBehavior.Restrict); // prevent CourseTag from deleting Course

            builder.HasMany(c => c.Feedbacks)
                   .WithOne(f => f.Course)
                   .HasForeignKey(f => f.CourseID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Instructor)
                   .WithMany(i => i.Courses)
                   .HasForeignKey(c => c.InstructorID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Status)
                   .WithMany()
                   .HasForeignKey(c => c.StatusID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.CREATEDBYUSER)
                   .WithMany()
                   .HasForeignKey(c => c.CREATEDBY)
                   .OnDelete(DeleteBehavior.Restrict); // or .SetNull

            builder.HasOne(c => c.MODIFIEDBYUSER)
                   .WithMany()
                   .HasForeignKey(c => c.MODIFIEDBY)
                   .OnDelete(DeleteBehavior.Restrict); // or .SetNull
            
            // Many-to-many for Categories/Tags can use UsingEntity with join table names if needed.

        }
    }
}
