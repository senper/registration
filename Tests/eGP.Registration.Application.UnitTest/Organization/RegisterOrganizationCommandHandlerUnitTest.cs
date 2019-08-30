using System;
using System.Collections.Generic;
using System.Text;
using eGP.Abstraction.Application.Idempotency;
using MediatR;
using Moq;

namespace eGP.Registration.Application.UnitTest.Organization
{
    public class RegisterOrganizationCommandHandlerUnitTest
    {
        private readonly Mock<IRequestManager> _requestManager;
        private readonly Mock<IMediator> _mediator;
    }
}
