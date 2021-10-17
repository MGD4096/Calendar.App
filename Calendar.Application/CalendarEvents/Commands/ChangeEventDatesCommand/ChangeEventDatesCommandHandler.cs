using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Calendar.Application.Configuration.Commands;
using Calendar.Domain.CalendarEvents;
using Calendar.Domain.Calendars;
using MediatR;

namespace Calendar.Application.CalendarEvents.ChangeEventDatesCommand
{
    internal class ChangeEventDatesCommandHandler : ICommandHandler<ChangeEventDatesCommand>
    {
        private readonly ICalendarEventRepository _calendarEventRepository;

        internal ChangeEventDatesCommandHandler(
            ICalendarEventRepository calendarRepository)
        {
            _calendarEventRepository = calendarRepository;
        }

        public async Task<Unit> Handle(ChangeEventDatesCommand request, CancellationToken cancellationToken)
        {
            var cEvent = await _calendarEventRepository.GetByIdAsync(new CalendarEventId(request.EventId));
            cEvent.ChangeDatesOfEvent(request.startDate, request.endDate, new Domain.Users.UserId(request.UserId));
            await _calendarEventRepository.Commit();
            return Unit.Value;
        }
    }
}