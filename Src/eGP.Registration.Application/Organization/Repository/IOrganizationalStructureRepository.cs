using System;
using eGP.Abstration.Domain;
using eGP.Registration.Domain.Organization;

namespace eGP.Registration.Application.Organization.Repository
{
    public interface IOrganizationalStructureRepository: IRepository<OrganizationalStructure>
    {
        Domain.Organization.Organization FindById(Guid OrganizationId, Guid id);
        Domain.Organization.Organization FindName(Guid OrganizationId, string name);
        void Add(Domain.Organization.Organization organization);
    }
}