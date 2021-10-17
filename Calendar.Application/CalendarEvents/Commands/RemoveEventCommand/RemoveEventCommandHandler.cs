using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Calendar.Application.Configuration.Commands;
using Calendar.Domain.CalendarEvents;
using Calendar.Domain.Calendars;
using MediatR;

namespace Calendar.Application.CalendarEvents.RemoveEventCommand
{
    internal class RemoveEventCommandHandler : ICommandHandler<RemoveEventCommand>
    {
        private readonly ICalendarEventRepository _calendarEventRepository;

        internal RemoveEventCommandHandler(
            ICalendarEventRepository calendarRepository)
        {
            _calendarEventRepository = calendarRepository;
        }

        public async Task<Unit> Handle(RemoveEventCommand request, CancellationToken cancellationToken)
        {
            var cEvent = await _calendarEventRepository.GetByIdAsync(new CalendarEventId(request.EventId));
            cEvent.RemoveEvent(new Domain.Users.UserId(request.UserId));
            await _calendarEventRepository.Commit();
            return Unit.Value;
        }
    }
}