using ArrayELearnApi.Domain.Entities;
using ArrayELearnApi.Domain.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArrayELearnApi.Infrastructure.Configurations
{
    internal sealed class GenderConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.HasKey(g => g.ID);

            builder.Property(g => g.Name).IsRequired();
            builder.Property(g => g.CREATIONDATE).HasDefaultValueSql("GETDATE()");

            //builder.HasOne(g => g.Status)
            //       .WithMany()
            //       .HasForeignKey(g => g.StatusID)
            //       .OnDelete(DeleteBehavior.Restrict);

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
