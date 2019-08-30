using System;
using MediatR;

namespace eGP.Registration.Application.Organization.Commands
{
    public class ChangeOrganizationNameCommand : IRequest<int>
    {
        public Guid Id { get;  set; }
        public string Name { get;  set; }

        public string ShortName { get;  set; }

        public string ChangedBy { get;  set; }
    }
}