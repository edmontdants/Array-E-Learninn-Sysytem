using ArrayELearnApi.Application.Interfaces.Auth;
using ArrayELearnApi.Application.Interfaces.Repositories;
using ArrayELearnApi.Application.Interfaces.Repositories.Base;
using ArrayELearnApi.Application.Interfaces.UoW;
using ArrayELearnApi.Application.Services.Auth;
using ArrayELearnApi.Infrastructure.Repositories;
using ArrayELearnApi.Infrastructure.Repositories.Base;
using ArrayELearnApi.Infrastructure.Services.Auth;
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
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IInstructorRepository, InstructorRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ISubmissionRepository, SubmissionRepository>();
            //services.AddScoped<IUserRoleRepository, UserRoleRepository>();

            //services.AddScoped<DbContext, ApplicationDbContext>();
            //services.AddScoped(typeof(IRepository<>), typeof(Repository<,>));
            //services.AddScoped(typeof(IApplicationRepository<>), typeof(ApplicationRepository<>));
            //services.AddScoped(typeof(ILoggingRepository<>), typeof(LoggingRepository<>));
            //services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            services.AddScoped<IApplicationUnitOfWork, ApplicationUnitOfWork>();
            //services.AddScoped<ILoggingUnitOfWork, UnitOfWork<LoggingDbContext>>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserClaimsResolverService, UserClaimsResolverService>();
            services.AddScoped<IUserRoleService, UserRoleService>();
            services.AddScoped<RefreshTokenService>();
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

            return services;
        }
    }
}
