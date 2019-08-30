using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace eGP.Registration.Application.Organization.DomainEventHandler
{
    public class OrganizationNameChangeDomainEvent : INotification
    {
        public Domain.Organization.Organization Organization { get; }

        public OrganizationNameChangeDomainEvent(Domain.Organization.Organization organization)
        {
            Organization = organization;
        }
    }
}
