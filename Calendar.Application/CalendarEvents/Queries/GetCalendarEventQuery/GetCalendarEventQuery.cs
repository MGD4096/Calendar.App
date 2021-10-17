using Calendar.Application.CalendarEvents;
using Calendar.Application.Configuration.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Application.CalendarEvents.GetCalendarEventQuery
{
    public class GetCalendarEventQuery : QueryBase<CalendarEventsDetailsDto>
    {
        public GetCalendarEventQuery(Guid eventId)
        {
            EventId = eventId;
        }

        public Guid EventId { get; set; }
    }
}
