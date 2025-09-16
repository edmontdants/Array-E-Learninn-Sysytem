using ArrayELearnApi.Application.Behaviors;
using ArrayELearnApi.Application.Features.Auth.Commands;
using ArrayELearnApi.Application.Profiles;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ArrayELearnApi.Application.Extensions
{
    public static class ApplicationDependencyInjectionExtensions
    {
        internal static readonly Assembly Assembly = typeof(ApplicationDependencyInjectionExtensions).Assembly;

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());
            
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(RefreshTokenCommand).Assembly));

            services.AddValidatorsFromAssembly(Assembly, includeInternalTypes: true);
            //services.AddValidatorsFromAssembly(Assembly.GetAssembly(typeof(ApplicationDependencyInjection)));
            //services.AddValidatorsFromAssembly(typeof(ApplicationDependencyInjection).Assembly);
            //services.AddValidatorsFromAssembly(Assembly.Load("ArrayELearnApi.Application"));
            //services.AddValidatorsFromAssemblyContaining<RegisterRequestAsyncValidator>();
            //services.AddValidatorsFromAssemblyContaining(typeof(ApplicationDependencyInjection));
            //services.AddFluentValidationAutoValidation();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehavior<,>));

            return services;
        }
    }
}
