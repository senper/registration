using System;
using MediatR;

namespace eGP.Registration.Application.Organization.Commands
{
    public class SetOrganizationProfileCommand : IRequest<int>
    {
        public Guid Id { get;  set; }
        public string Profile { get;  set; }

        public string ChangedBy { get;  set; }

        
    }
}