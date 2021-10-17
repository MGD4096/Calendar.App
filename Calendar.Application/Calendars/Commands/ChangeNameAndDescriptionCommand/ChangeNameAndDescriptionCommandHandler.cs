using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Calendar.Application.Configuration.Commands;
using Calendar.Domain.Calendars;
using MediatR;

namespace Calendar.Application.Calendars.ChangeNameAndDescriptionCommand
{
    internal class CreateNewCalendarCommandHandler : ICommandHandler<ChangeNameAndDescriptionCommand>
    {
        private readonly ICalendarRepository _calendarRepository;

        internal CreateNewCalendarCommandHandler(
            ICalendarRepository deviceRepository)
        {
            _calendarRepository = deviceRepository;
        }

        public async Task<Unit> Handle(ChangeNameAndDescriptionCommand request, CancellationToken cancellationToken)
        {
            var calendar = await _calendarRepository.GetByIdAsync(new CalendarId(request.CalendarId));
            calendar.ChangeNameAndDescription(request.CalendarName, request.CalendarName);
            await _calendarRepository.Commit();
            return Unit.Value;
        }
    }
}