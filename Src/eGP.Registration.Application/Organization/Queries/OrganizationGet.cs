using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using eGP.Registration.Application.Organization.Repository;
using MediatR;

namespace eGP.Registration.Application.Organization.Queries
{
    public class OrganizationGetAllQuery: IRequest<OrganizationDTOList>
    {
    }

    public class OrganizationGetByIdQuery : IRequest<OrganizationDTO>
    {
        public Guid Id { get; set; }
    }

    public class OrganizationGetAllQueryHandler : 
        IRequestHandler<OrganizationGetAllQuery, OrganizationDTOList>,
        IRequestHandler<OrganizationGetByIdQuery, OrganizationDTO>
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly string _connectionString;
        public OrganizationGetAllQueryHandler(IOrganizationRepository repository, string connectionString)
        {
            _organizationRepository = repository;
            _connectionString = connectionString;
        }
        public async Task<OrganizationDTOList> Handle(OrganizationGetAllQuery request, CancellationToken cancellationToken)
        {
            var lst = await _organizationRepository.FindAll(cancellationToken);
            var dtoList = new OrganizationDTOList();
            foreach (var domain in lst)
            {
                dtoList.Organizations.Add(OrganizationDTO.MapFrom(domain));
            }
            return dtoList;
        }

        public async Task<OrganizationDTO> Handle(OrganizationGetByIdQuery request, CancellationToken cancellationToken)
        {
            var org = await _organizationRepository.FindById(request.Id, cancellationToken);
            return OrganizationDTO.MapFrom(org);
        }
    }
}
