using System;
using System.Collections.Generic;
using System.Text;
using eGP.Registration.Application.Organization.Commands;
using FluentValidation;
using MediatR;

namespace eGP.Registration.Application.Organization.Validations
{
    public class RegisterOrganizationValidator : AbstractValidator<RegisterOrganizationCommand>
    {
        private readonly IMediator _mediator;
        public RegisterOrganizationValidator()//(IMediator mediator)
        {
          //  _mediator = mediator;
            SetRules();
        }

        void SetRules()
        {
            RuleFor(x => x.Name).Length(5).WithErrorCode(ErrorCode.LengthTooSmall);
            RuleFor(x => x.RegisteredBy).Length(5).WithErrorCode(ErrorCode.LengthTooSmall);
        }
    }
}
