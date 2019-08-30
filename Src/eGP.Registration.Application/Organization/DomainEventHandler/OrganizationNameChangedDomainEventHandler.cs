using GP.Registration.Domain.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace eGP.Registration.Application.Organization.DomainEventHandler
{
    public class OrganizationNameChangedDomainEventHandler : INotificationHandler<OrganizationNameChangeDomainEvent>
    {

        public OrganizationNameChangedDomainEventHandler()
        {

        }

        public async Task Handle(OrganizationNameChangeDomainEvent orderCancelledDomainEvent, CancellationToken cancellationToken)
        {
            //Do Handle
        }
    }
}
