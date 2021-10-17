using Calendar.Application.Configuration.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Application.Calendars.GetCalendarQuery
{
    public class GetCalendarQuery : QueryBase<CalendarDetailsDto>
    {
        public GetCalendarQuery(Guid calendarId)
        {
            CalendarId = calendarId;
        }

        public Guid CalendarId { get; set; }
    }
}
