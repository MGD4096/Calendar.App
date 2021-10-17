using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Calendar.Application.Configuration.Commands;
using Calendar.Domain.CalendarEvents;
using Calendar.Domain.Calendars;
using MediatR;

namespace Calendar.Application.CalendarEvents.ChangeMainAttributesCommand
{
    internal class ChangeMainAttributesCommandHandler : ICommandHandler<ChangeMainAttributesCommand>
    {
        private readonly ICalendarEventRepository _calendarEventRepository;

        internal ChangeMainAttributesCommandHandler(
            ICalendarEventRepository calendarEventRepository)
        {
            _calendarEventRepository = calendarEventRepository;
        }

        public async Task<Unit> Handle(ChangeMainAttributesCommand request, CancellationToken cancellationToken)
        {
            var cEvent = await _calendarEventRepository.GetByIdAsync(new CalendarEventId(request.EventId));
            cEvent.ChangeMainAttributes(request.EventName, request.EventDescription,new Domain.Users.UserId(request.Owner));
            await _calendarEventRepository.Commit();
            return Unit.Value;
        }
    }
}