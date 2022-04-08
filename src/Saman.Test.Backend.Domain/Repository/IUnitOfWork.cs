using System;
using System.Threading;
using System.Threading.Tasks;

namespace Saman.Test.Backend.Domain.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default);
    }
}
