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
            builder.HasIndex(i => i.UserID).IsUnique();

            builder.Property(i => i.Education).HasMaxLength(200);
            builder.Property(i => i.Designation).HasMaxLength(200);
            builder.Property(i => i.UserID).IsRequired().HasMaxLength(450);
            builder.Property(i => i.CREATIONDATE).HasDefaultValueSql("GETDATE()");

            builder.HasOne(i => i.User)
                   .WithMany(u => u.Instructors)
                   .HasForeignKey(i => i.UserID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(i => i.CREATEDBYUSER)
                   .WithMany()  // one user can create many instructors
                   .HasForeignKey(i => i.CREATEDBY)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(i => i.MODIFIEDBYUSER)
                   .WithMany()  // one user can modify many instructors
                   .HasForeignKey(i => i.MODIFIEDBY)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
