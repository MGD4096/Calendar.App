using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Calendar.Application.Configuration.Commands;
using Calendar.Domain.Calendars;
using MediatR;

namespace Calendar.Application.Calendars.CreateNewCalendarCommand
{
    internal class CreateNewCalendarCommandHandler : ICommandHandler<CreateNewCalendarCommand>
    {
        private readonly ICalendarRepository _calendarRepository;

        internal CreateNewCalendarCommandHandler(
            ICalendarRepository deviceRepository)
        {
            _calendarRepository = deviceRepository;
        }

        public async Task<Unit> Handle(CreateNewCalendarCommand request, CancellationToken cancellationToken)
        {
            await _calendarRepository.AddAsync(
                Calendar.Domain.Calendars.Calendar.CreateNew(
                    request.CalendarName,
                    request.CalendarDescription,
                    new Domain.Users.UserId(request.Owner),
                    request.IsPublic,
                    request.EventsCanBeModifiedBySubscriber
                ));
            await _calendarRepository.Commit();
            return Unit.Value;
        }
    }
}