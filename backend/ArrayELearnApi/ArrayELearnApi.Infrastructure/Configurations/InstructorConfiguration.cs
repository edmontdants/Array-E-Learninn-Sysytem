using ArrayELearnApi.Domain.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArrayELearnApi.Infrastructure.Configurations
{
    internal sealed class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasKey(i => i.ID);

            builder.Property(i => i.UserID).IsRequired().HasMaxLength(450);
            builder.HasIndex(i => i.UserID).IsUnique();

            builder.Property(i => i.Designation).HasMaxLength(200);
            builder.Property(i => i.Education).HasMaxLength(400);
            
            builder.Property(e => e.CREATIONDATE).HasDefaultValueSql("GETDATE()");

            builder.HasOne(i => i.User)
                   .WithOne(u => u.Instructor)
                   .HasForeignKey<Instructor>(i => i.UserID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.Courses)
                   .WithOne(i => i.Instructor)
                   .HasForeignKey(c => c.ID)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
