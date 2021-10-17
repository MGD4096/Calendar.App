using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Calendar.Application.Configuration.Commands;
using Calendar.Domain.Calendars;
using MediatR;

namespace Calendar.Application.Calendars.RemoveCalendarCommand
{
    internal class RemoveCalendarCommandHandler : ICommandHandler<RemoveCalendarCommand>
    {
        private readonly ICalendarRepository _calendarRepository;

        internal RemoveCalendarCommandHandler(
            ICalendarRepository deviceRepository)
        {
            _calendarRepository = deviceRepository;
        }

        public async Task<Unit> Handle(RemoveCalendarCommand request, CancellationToken cancellationToken)
        {
            var calendar = await _calendarRepository.GetByIdAsync(new CalendarId(request.CalendarId));
            calendar.Remove();
            await _calendarRepository.Commit();
            return Unit.Value;
        }
    }
}