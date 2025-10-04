using ArrayELearnApi.Application.Interfaces.Repositories;
using System.Data;

namespace ArrayELearnApi.Application.Interfaces.UoW
{
    public interface ILoggingUnitOfWork : IUnitOfWork, IDisposable, IAsyncDisposable
    {

    }
}
