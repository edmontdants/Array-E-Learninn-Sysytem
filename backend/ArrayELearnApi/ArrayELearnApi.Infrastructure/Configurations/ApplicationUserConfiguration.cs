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

            builder.Property(u => u.UserName).IsRequired().HasMaxLength(100);
            builder.HasIndex(u => u.UserName).IsUnique();

            builder.Property(x => x.Email).IsRequired().HasMaxLength(255);
            builder.HasIndex(x => x.Email).IsUnique();

            builder.Property(u => u.FirstName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(u => u.LastName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(u => u.FullName)
                   .HasComputedColumnSql("[FirstName] + ' ' + [LastName]", stored: true);

            builder.Property(u => u.DateOfBirth)
                   .IsRequired();

            builder.Property(u => u.JoinedAt)
                   .HasDefaultValueSql("GETDATE()");

            builder.Property(u => u.CREATIONDATE)
                   .HasDefaultValueSql("GETDATE()");

            //builder.Property(u => u.Gender)
            //    .HasConversion<int>() // store enum as int
            //    .IsRequired();

            builder.HasOne(u => u.Gender)
                   .WithMany(g => g.Users)
                   .HasForeignKey(u => u.GenderID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(u => u.ProfilePictureUrl)
                .HasMaxLength(500);

            builder.HasMany(u => u.Notifications)
                   .WithOne(n => n.User)
                   .HasForeignKey(n => n.UserID)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
