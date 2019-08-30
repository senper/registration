using eGP.Registration.Application.Organization.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace eGP.Registration.Application.Organization.Validations
{
    public class ChangeOrganizationNameValidator : AbstractValidator<ChangeOrganizationNameCommand>
    {
        public ChangeOrganizationNameValidator()
        {
            //  _mediator = mediator;
            SetRules();
        }

        void SetRules()
        {
            RuleFor(x => x.Name).Length(5).WithErrorCode(ErrorCode.LengthTooSmall);
            RuleFor(x => x.ShortName).Length(5).WithErrorCode(ErrorCode.LengthTooSmall);
        }
    }
}
