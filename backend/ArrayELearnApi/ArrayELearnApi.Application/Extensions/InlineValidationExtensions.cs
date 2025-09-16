using FluentValidation;
using FluentValidation.Results;
//using System.ComponentModel.DataAnnotations;

namespace ArrayELearnApi.Application.Extensions
{
    internal static class InlineValidationExtensions
    {
        public static Task<ValidationResult> ValidateInlineAsync<T>(this T obj, Action<InlineValidator<T>> configure)
        {
            var validator = new InlineValidator<T>();
            configure(validator);
            return validator.ValidateAsync(obj);
        }
    }
}
