﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using eGP.Abstration.Domain;
using FluentValidation;
using MediatR;
using ValidationException = System.ComponentModel.DataAnnotations.ValidationException;

namespace eGP.Abstraction.Application.Behaviors
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public class ValidatorBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IValidator<TRequest>[] _validators;
        public ValidatorBehavior(IValidator<TRequest>[] validators) => _validators = validators;

        public async Task<TResponse> Handle(TRequest request, 
            CancellationToken cancellationToken, 
            RequestHandlerDelegate<TResponse> next)
        {
            var failures = _validators
                .Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(error => error != null)
                .ToList();

            if (failures.Any())
            {
                
                throw new FluentValidation.ValidationException(
                    $"Command Validation Errors for type {typeof(TRequest).Name}",  failures);
            }

            var response = await next();
            return response;
        }
    }
}
