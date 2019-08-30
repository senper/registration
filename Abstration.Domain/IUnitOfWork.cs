using System;
using System.Threading;
using System.Threading.Tasks;

namespace eGP.Abstration.Domain
{
    public interface IUnitOfWork : IDisposable
    {

        int SaveChanges(string userid);
        Task<int> SaveChangesAsync(string userid, CancellationToken cancellationToken = default(CancellationToken));
        Task<int> SaveEntitiesAsync(string userid, CancellationToken cancellationToken = default(CancellationToken));
    }
}