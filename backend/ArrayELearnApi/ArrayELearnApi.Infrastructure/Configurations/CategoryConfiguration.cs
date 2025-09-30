using ArrayELearnApi.Domain.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArrayELearnApi.Infrastructure.Configurations
{
    internal sealed class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.ID);

            builder.Property(c => c.Name).IsRequired().HasMaxLength(200);
            builder.Property(c => c.CREATIONDATE).HasDefaultValueSql("GETDATE()");

            builder.HasOne(c => c.Status)
                   .WithMany()
                   .HasForeignKey(c => c.StatusID)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
