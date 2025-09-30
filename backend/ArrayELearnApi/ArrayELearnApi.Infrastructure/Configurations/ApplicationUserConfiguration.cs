using ArrayELearnApi.Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArrayELearnApi.Infrastructure.Configurations
{
    internal sealed class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            // Keys & indexes
            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.Email).IsUnique();
            builder.HasIndex(u => u.UserName).IsUnique();

            builder.Property(u => u.Email).IsRequired().HasMaxLength(256);
            builder.Property(u => u.UserName).IsRequired().HasMaxLength(256);
            builder.Property(u => u.PhoneNumber).HasMaxLength(100);
            builder.Property(u => u.FirstName).HasMaxLength(100);
            builder.Property(u => u.LastName).HasMaxLength(100);
            builder.Property(u => u.ProfilePictureUrl).HasMaxLength(500);
            builder.Property(u => u.SecurityStamp).HasMaxLength(4000);
            builder.Property(u => u.ConcurrencyStamp).HasMaxLength(4000);
            builder.Property(u => u.PasswordHash).HasMaxLength(4000);
            builder.Property(u => u.JoinedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(u => u.CREATIONDATE).HasDefaultValueSql("GETDATE()");

            builder.Property(u => u.FullName)
                   .HasMaxLength(200)
                   .HasComputedColumnSql("[FirstName] + ' ' + [LastName]", stored: true);

            //builder.Property(u => u.Gender)
            //    .HasConversion<int>() // store enum as int
            //    .IsRequired();

            builder.HasOne(u => u.Gender)
                   .WithMany(g => g.Users)
                   .HasForeignKey(u => u.GenderID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.CREATEDBYUSER)
                   .WithMany(u => u.CREATEDUSERS)
                   .HasForeignKey(u => u.CREATEDBY)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.MODIFIEDBYUSER)
                   .WithMany(u => u.MODIFIEDUSERS)
                   .HasForeignKey(u => u.MODIFIEDBY)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
