namespace ArrayELearnApi.Application.Interfaces
{
    public interface IValidationService
    {
        Task ValidateAsync<T>(T model, CancellationToken cancellation = default);
    }
}
