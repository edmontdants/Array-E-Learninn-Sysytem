using ArrayELearnApi.Domain.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArrayELearnApi.Infrastructure.Configurations
{
    internal sealed class FeeConfiguration : IEntityTypeConfiguration<Fee>
    {
        public void Configure(EntityTypeBuilder<Fee> builder)
        {
            builder.HasKey(f => f.ID);

            builder.Property(f => f.Amount).HasColumnType("decimal(12,2)");
            builder.Property(f => f.Description).HasMaxLength(1000);
            builder.Property(e => e.CREATIONDATE).HasDefaultValueSql("GETDATE()");

            builder.HasOne(f => f.Status)
                   .WithMany()
                   .HasForeignKey(f => f.StatusID)
                   .OnDelete(DeleteBehavior.Restrict); // prevents cascade

            builder.HasOne(f => f.Student)
                   .WithMany(s => s.Fees)
                   .HasForeignKey(f => f.StudentID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(f => f.Instructor)
                   .WithMany(i => i.Fees)
                   .HasForeignKey(f => f.InstructorID)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
