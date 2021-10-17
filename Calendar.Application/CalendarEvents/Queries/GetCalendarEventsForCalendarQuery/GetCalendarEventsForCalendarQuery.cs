using Calendar.Application.CalendarEvents;
using Calendar.Application.Configuration.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Application.CalendarEvents.GetCalendarEventsForCalendarQuery
{
    public class GetCalendarEventsForCalendarQuery : QueryBase<List<CalendarEventDto>>
    {
        public GetCalendarEventsForCalendarQuery(Guid calendarId)
        {
            CalendarId = calendarId;
        }

        public Guid CalendarId { get; set; }
    }
}
