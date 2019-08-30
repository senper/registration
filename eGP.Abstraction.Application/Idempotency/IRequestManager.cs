using System;
using System.Threading.Tasks;

namespace eGP.Abstraction.Application.Idempotency
{
    public interface IRequestManager
    {
        Task<bool> ExistAsync(Guid id);

        Task CreateRequestForCommandAsync<T>(Guid id);
    }
}
