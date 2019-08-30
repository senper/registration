using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using eGP.Abstration.Domain;

namespace eGP.Registration.Application.Organization.Repository
{
    public interface IOrganizationRepository : IRepository<Domain.Organization.Organization>
    {
        Task<IEnumerable<Domain.Organization.Organization>> FindAll(CancellationToken cancellationToken);
        Task<Domain.Organization.Organization> FindById(Guid id, CancellationToken cancellationToken);

        Task<IEnumerable<Domain.Organization.Organization>>
            FindByName(string name, CancellationToken cancellationToken);

        void Add(Domain.Organization.Organization organization);
        string GetNewCode();
        void ChangeName(Domain.Organization.Organization newOrganization);
        void ChangeVersion(Domain.Organization.Organization newOrganization);
        void SetProfile(Domain.Organization.Organization newOrganization);
    }
}
