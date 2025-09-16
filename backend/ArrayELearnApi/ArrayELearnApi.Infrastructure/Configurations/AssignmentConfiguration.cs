using ArrayELearnApi.Domain.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArrayELearnApi.Infrastructure.Configurations
{
    internal sealed class AssignmentConfiguration : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder.HasKey(a => a.ID);

            builder.Property(a => a.Title).IsRequired().HasMaxLength(200);
            builder.Property(a => a.Description).HasMaxLength(4000);
            builder.Property(a => a.DueDate).IsRequired();

            builder.Property(n => n.CREATIONDATE)
                   .HasDefaultValueSql("GETDATE()");

            builder.HasOne(a => a.Status)
                   .WithMany()
                   .HasForeignKey(a => a.StatusID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Course)
                   .WithMany(c => c.Assignments)
                   .HasForeignKey(a => a.CourseID)
                   .OnDelete(DeleteBehavior.Cascade);

            // OPTIONAL audit:
            // builder.Property(a => a.CreatedByUserId).HasMaxLength(450);
            // builder.HasOne<ApplicationUser>()
            //        .WithMany()
            //        .HasForeignKey(a => a.CreatedByUserId)
            //        .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
