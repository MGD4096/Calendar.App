using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Calendar.Application.Configuration.Commands;
using Calendar.Application.Contracts;
using Domain.BuildingBlocks.Infrastructure.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Calendar.Infrastructure.Configuration.Processing
{
    internal class UnitOfWorkCommandHandlerDecorator<T> : ICommandHandler<T>
        where T : ICommand
    {
        private readonly ICommandHandler<T> _decorated;
        private readonly IUnitOfWork _unitOfWork;
        private readonly CalendarContext _calendarContext;

        public UnitOfWorkCommandHandlerDecorator(
            ICommandHandler<T> decorated,
            IUnitOfWork unitOfWork,
            CalendarContext calendarContext)
        {
            _decorated = decorated;
            _unitOfWork = unitOfWork;
            _calendarContext = calendarContext;
        }

        public async Task<Unit> Handle(T command, CancellationToken cancellationToken)
        {
            await this._decorated.Handle(command, cancellationToken);

            if (command is InternalCommandBase)
            {
                var internalCommand =
                    await _calendarContext.InternalCommands.FirstOrDefaultAsync(
                        x => x.Id == command.Id,
                        cancellationToken: cancellationToken);

                if (internalCommand != null)
                {
                    internalCommand.ProcessedDate = DateTime.UtcNow;
                }
            }

            await this._unitOfWork.CommitAsync(cancellationToken);

            return Unit.Value;
        }
    }
}