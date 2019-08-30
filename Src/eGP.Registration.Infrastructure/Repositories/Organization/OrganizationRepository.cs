using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using eGP.Abstration.Domain;
using eGP.Registration.Application.Organization.Repository;
using eGP.Registration.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;

namespace eGP.Registration.Persistance.Repositories.Organization
{
    public class OrganizationRepository: IOrganizationRepository
    {
        private readonly RegistrationDbContext _dbContext;

        public IUnitOfWork UnitOfWork => _dbContext;

        public OrganizationRepository(RegistrationDbContext dbContext)
        {
            _dbContext = dbContext;
           
        }

        public async Task<IEnumerable<Domain.Organization.Organization>> FindAll(CancellationToken cancellationToken)
        {
            return await _dbContext.Organizations
                .Select(EntityModels.Organization.Projection).ToListAsync(cancellationToken);
        }

        public async Task<Domain.Organization.Organization> FindById(Guid id, CancellationToken cancellationToken)
        {
            var organization = await _dbContext.Organizations.FirstOrDefaultAsync(o => o.Id == id,cancellationToken);
            if (organization == null)
            {
                throw new KeyNotFoundException($"No organization with id {id}");
            }
           
            return organization.ToModel;
        }

        public async Task<IEnumerable<Domain.Organization.Organization>> FindByName(string name, CancellationToken cancellationToken)
        {
           return await _dbContext.Organizations
                .Where(o => o.Name.StartsWith(name))
                .Select(EntityModels.Organization.Projection).ToListAsync(cancellationToken);
        }

        public void Add(Domain.Organization.Organization organization)
        {
            _dbContext.Organizations.Add(EntityModels.Organization.FromModel(organization));
        }

        public string GetNewCode()
        {
                var builder = new StringBuilder();
                Enumerable
                    .Range(65, 26)
                    .Select(e => ((char)e).ToString())
                    .Concat(Enumerable.Range(97, 26).Select(e => ((char)e).ToString()))
                    .Concat(Enumerable.Range(0, 10).Select(e => e.ToString()))
                    .OrderBy(e => Guid.NewGuid())
                    .Take(5)
                    .ToList().ForEach(e => builder.Append(e));
                return builder.ToString();
            
        }

        public void ChangeName(Domain.Organization.Organization newOrganization)
        {
            var entity = _dbContext.Organizations.FirstOrDefault( o => o.Id == newOrganization.Id);
            if (entity == null)
            {
                throw new KeyNotFoundException();
            }

            entity.Name = newOrganization.Name;
            entity.ShortName = newOrganization.ShortName;
            _dbContext.Update(entity);
        }

        public void ChangeVersion(Domain.Organization.Organization newOrganization)
        {
            var entity = _dbContext.Organizations.FirstOrDefault(o => o.Id == newOrganization.Id);
            if (entity == null)
            {
                throw new KeyNotFoundException();
            }

            entity.Version = newOrganization.Version;
            _dbContext.Update(entity);
        }

        public void SetProfile(Domain.Organization.Organization newOrganization)
        {
            var entity = _dbContext.Organizations.FirstOrDefault(o => o.Id == newOrganization.Id);
            if (entity == null)
            {
                throw new KeyNotFoundException();
            }

            entity.Profile = newOrganization.Profile;
            _dbContext.Update(entity);
        }
    }
}
