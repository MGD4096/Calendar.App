using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Calendar.Application.Configuration.Commands;
using Calendar.Domain.CalendarEvents;
using Calendar.Domain.Calendars;
using Calendar.Domain.Users;
using MediatR;

namespace Calendar.Application.CalendarEvents.AddCalendarEventCommand
{
    internal class CreateNewCalendarCommandHandler : ICommandHandler<AddCalendarEventCommand>
    {
        private readonly ICalendarRepository _calendarRepository;
        private readonly ICalendarEventRepository _calendarEventRepository;

        internal CreateNewCalendarCommandHandler(
            ICalendarRepository calendarRepository,
            ICalendarEventRepository calendarEventRepository
            )
        {
            _calendarRepository = calendarRepository;
            _calendarEventRepository = calendarEventRepository;
        }

        public async Task<Unit> Handle(AddCalendarEventCommand request, CancellationToken cancellationToken)
        {
            var calendar = await _calendarRepository.GetByIdAsync(new CalendarId(request.CalendarId));
            var cEvent = calendar.AddEvent(
                request.EventName,
                request.EventDescription,
                new UserId(request.UserId),
                request.StartDate,
                request.EndDate,
                request.AllDayEvent,
                request.NotifyBefore,
                new UserId(request.UserId),
                new UserId(request.UserId)
                );
            await _calendarEventRepository.AddAsync(cEvent);
            await _calendarEventRepository.Commit();
            return Unit.Value;
        }
    }
}