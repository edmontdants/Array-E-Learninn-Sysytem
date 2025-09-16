using ArrayELearnApi.Infrastructure.Persistence;

namespace ArrayELearnApi.Application.Services
{
    public class TokenCleanupService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public TokenCleanupService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                    var expired = context.RefreshTokens.Where(t => t.Expires < DateTime.Now);
                    context.RefreshTokens.RemoveRange(expired);
                    await context.SaveChangesAsync();
                }
                await Task.Delay(TimeSpan.FromHours(6), stoppingToken); // Run every 6 hours
            }
        }
    }
}
