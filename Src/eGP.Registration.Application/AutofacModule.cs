using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Threading.Tasks;
using Autofac;
using eGP.Abstraction.Application.Behaviors;
using eGP.Registration.Application.Organization.Commands;
using eGP.Registration.Application.Organization.DomainEventHandler;
using eGP.Registration.Application.Organization.Repository;
using eGP.Registration.Application.Organization.Validations;
using eGP.Registration.Domain.Organization;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using Module = Autofac.Module;

namespace eGP.Registration.API
{
    public class MediatorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(typeof(RegisterOrganizationCommand).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder.RegisterAssemblyTypes(typeof(OrganizationNameChangedDomainEventHandler).GetTypeInfo().Assembly)
               .AsClosedTypesOf(typeof(INotificationHandler<>));

            builder
                .RegisterAssemblyTypes(typeof(RegisterOrganizationValidator).GetTypeInfo().Assembly)
                .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
                .AsImplementedInterfaces();

            builder.RegisterGeneric(typeof(LoggingBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            builder.RegisterGeneric(typeof(ValidatorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            //builder.RegisterGeneric(typeof(TransactionBehaviour<,>)).As(typeof(IPipelineBehavior<,>));

        }
    }
}
