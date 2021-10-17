﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using FluentValidation;
using MediatR;
using Calendar.Application.Configuration.Commands;
using Calendar.Application.Contracts;
using Domain.BuildingBlocks.Application;

namespace Calendar.Infrastructure.Configuration.Processing
{
    internal class ValidationCommandHandlerDecorator<T> : ICommandHandler<T>
        where T : ICommand
    {
        private readonly IList<IValidator<T>> _validators;
        private readonly ICommandHandler<T> _decorated;

        public ValidationCommandHandlerDecorator(
            IList<IValidator<T>> validators,
            ICommandHandler<T> decorated)
        {
            this._validators = validators;
            _decorated = decorated;
        }

        public Task<Unit> Handle(T command, CancellationToken cancellationToken)
        {
            var errors = _validators
                .Select(v => v.Validate(command))
                .SelectMany(result => result.Errors)
                .Where(error => error != null)
                .ToList();

            if (errors.Any())
            {
                throw new InvalidCommandException(errors.Select(x => x.ErrorMessage).ToList());
            }

            return _decorated.Handle(command, cancellationToken);
        }
    }
}