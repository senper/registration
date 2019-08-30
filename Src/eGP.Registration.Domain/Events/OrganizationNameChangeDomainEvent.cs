using eGP.Registration.Domain.Organization;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GP.Registration.Domain.Events
{
    public class OrganizationNameChangeDomainEvent : INotification
    {
        public Organization Organization { get; }

        public OrganizationNameChangeDomainEvent(Organization organization)
        {
            Organization = organization;
        }
    }
}
