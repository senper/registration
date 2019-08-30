using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using eGP.Registration.Application.Organization.Repository;
using GP.Registration.Domain.Events;
using MediatR;

namespace eGP.Registration.Application.Organization.Commands
{
    /// <summary>
    /// Handles Update commands to the Organization, UpdateName, UpdateVersion, and UpdateProfile
    /// </summary>
    public class ChangeOrganizationHandler : 
        IRequestHandler<ChangeOrganizationNameCommand, int>,
        IRequestHandler<ChangeOrganizationVersionCommand, int>,
        IRequestHandler<SetOrganizationProfileCommand, int>
    {
        private readonly IOrganizationRepository _organizationRepository;

        public ChangeOrganizationHandler(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;

        }
        /// <summary>
        /// Handles Change Organization Name Command
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> Handle(ChangeOrganizationNameCommand request, CancellationToken cancellationToken)
        {
            var currentOrg = _organizationRepository.FindById(request.Id, cancellationToken).Result;
            currentOrg.ChangeName(request.Name, request.ShortName);
            _organizationRepository.ChangeName(currentOrg);

            try
            {
                return await _organizationRepository
                    .UnitOfWork
                    .SaveChangesAsync(request.ChangedBy);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Handles Change Version command
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> Handle(ChangeOrganizationVersionCommand request, CancellationToken cancellationToken)
        {
            var currentOrg = _organizationRepository.FindById(request.Id, cancellationToken).Result;
            currentOrg.ChangeVersion(request.VersionNo);
            _organizationRepository.ChangeName(currentOrg);

            try
            {
                return _organizationRepository
                    .UnitOfWork
                    .SaveChanges(request.ChangedBy);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Handler for setting organization profile
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> Handle(SetOrganizationProfileCommand request, CancellationToken cancellationToken)
        {
            var currentOrg = _organizationRepository.FindById(request.Id, cancellationToken).Result;
            currentOrg.SetProfile(request.Profile);
            _organizationRepository.ChangeName(currentOrg);

            try
            {
                return _organizationRepository
                    .UnitOfWork
                    .SaveChanges(request.ChangedBy);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
