using Calendar.Domain.Calendars;
using Domain.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Domain.Calendars.Events
{
    public class CalendarMainAttributesChangedDomainEvent: DomainEventBase
    {
        public CalendarMainAttributesChangedDomainEvent(CalendarId eventId)
        {
            EventId = eventId;
        }

        public CalendarId EventId { get; }
    }
}
