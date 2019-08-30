using System;
using System.Collections.Generic;
using System.Text;
using eGP.Registration.Domain.Organization;
using MediatR;

namespace eGP.Registration.Application.Organization.Commands
{
    public class ChangeOrganizationVersionCommand : IRequest<int>
    {
        public Guid Id { get;  set; }

        public string VersionNo { get;  set; }

        public string ChangedBy { get;  set; }
       
    }
}
