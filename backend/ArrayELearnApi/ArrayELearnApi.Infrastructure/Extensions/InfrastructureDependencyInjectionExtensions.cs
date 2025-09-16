using ArrayELearnApi.Application.Interfaces;
using ArrayELearnApi.Application.Interfaces.Auth;
using ArrayELearnApi.Application.Services.Auth;
using ArrayELearnApi.Domain.Interfaces.Repositories;
using ArrayELearnApi.Infrastructure.Persistence;
using ArrayELearnApi.Infrastructure.Repositories;
using ArrayELearnApi.Infrastructure.Services;
using ArrayELearnApi.Infrastructure.Services.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ArrayELearnApi.Infrastructure.Extensions
{
    public static class InfrastructureDependencyInjectionExtensions
    {
        internal static readonly Assembly Assembly = typeof(InfrastructureDependencyInjectionExtensions).Assembly;

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            //services.AddDbContext<ApplicationDbContext>(options =>
            //options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            ////.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
            //);
            
            //services.AddIdentity<ApplicationUser, IdentityRole>()
            //        .AddEntityFrameworkStores<ApplicationDbContext>()
            //        .AddDefaultTokenProviders();

            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ISubmissionRepository, SubmissionRepository>();
            //services.AddScoped<DbContext, ApplicationDbContext>();
            //services.AddScoped<IUserRoleRepository, UserRoleRepository>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserClaimsResolverService, UserClaimsResolverService>();
            services.AddScoped<IUserRoleService, UserRoleService>();
            services.AddScoped<RefreshTokenService>();
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

            return services;
        }
    }
}
