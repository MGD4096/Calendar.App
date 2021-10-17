using Calendar.Domain.CalendarEvents;
using Domain.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Domain.CalendarEvent.Events
{
    public class EventWasRemovedDomainEvent:DomainEventBase
    {
        public EventWasRemovedDomainEvent(CalendarEventId eventId)
        {
            EventId = eventId;
        }

        public CalendarEventId EventId { get; }
    }
}
