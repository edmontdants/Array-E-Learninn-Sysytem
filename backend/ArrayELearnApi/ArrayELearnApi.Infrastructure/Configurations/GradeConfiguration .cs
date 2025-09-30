using ArrayELearnApi.Domain.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArrayELearnApi.Infrastructure.Configurations
{
    internal sealed class GradeConfiguration : IEntityTypeConfiguration<Grade>
    {
        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            builder.HasKey(g => g.ID);

            builder.Property(g => g.Value).IsRequired();
            builder.Property(g => g.Remarks).HasMaxLength(1000);
            builder.Property(g => g.GradedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(g => g.CREATIONDATE).HasDefaultValueSql("GETDATE()");

            builder.HasOne(g => g.Status)
                   .WithMany()
                   .HasForeignKey(g => g.StatusID)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
