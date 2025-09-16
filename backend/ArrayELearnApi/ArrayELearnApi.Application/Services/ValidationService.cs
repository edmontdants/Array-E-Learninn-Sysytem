using ArrayELearnApi.Application.Interfaces;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace ArrayELearnApi.Application.Services
{
    public class ValidationService : IValidationService
    {
        private readonly IServiceProvider _serviceProvider;

        public ValidationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task ValidateAsync<T>(T model, CancellationToken cancellation = default)
        {
            var validator = _serviceProvider.GetService<IValidator<T>>();
            if (validator is null) return;

            var result = await validator.ValidateAsync(model, cancellation);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
