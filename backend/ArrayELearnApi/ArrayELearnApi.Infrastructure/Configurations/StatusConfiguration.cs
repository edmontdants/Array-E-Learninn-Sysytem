using ArrayELearnApi.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArrayELearnApi.Infrastructure.Configurations
{
    internal sealed class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.HasKey(s => s.ID);
            
            builder.Property(s => s.CREATIONDATE).HasDefaultValueSql("GETDATE()");

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
