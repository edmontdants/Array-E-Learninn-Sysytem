using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ArrayELearnApi.Infrastructure.Persistence
{
    internal class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>, IDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            // Get connection string
            var connectionString = "Server=localhost; Database=ArrayELearnDb; MultipleActiveResultSets=True; Trusted_Connection=True; TrustServerCertificate=True;";

            //var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            //                                       .AddJsonFile("appsettings.json")
            //                                       .AddEnvironmentVariables()
            //                                       .Build();

            //optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"))
            //              //.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
            //              .UseLazyLoadingProxies();

            optionsBuilder.UseSqlServer(connectionString)
                          //.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                          .UseLazyLoadingProxies();

            return new ApplicationDbContext(optionsBuilder.Options);
        }

        public ApplicationDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            // Get connection string
            var connectionString = "Server=localhost; Database=ArrayELearnDb; MultipleActiveResultSets=True; Trusted_Connection=True; TrustServerCertificate=True;";

            //var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            //                                       .AddJsonFile("appsettings.json")
            //                                       .AddEnvironmentVariables()
            //                                       .Build();

            //optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"))
            //              //.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
            //              .UseLazyLoadingProxies();

            optionsBuilder.UseSqlServer(connectionString)
                          //.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                          .UseLazyLoadingProxies();

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
