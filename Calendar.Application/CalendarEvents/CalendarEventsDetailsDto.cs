using Calendar.Domain.CalendarEvents;
using Calendar.Domain.Calendars;
using Calendar.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Application.CalendarEvents
{
    public class CalendarEventsDetailsDto
    {
        public Guid EventId { get; protected set; }
        public string EventName { get; protected set; }
        public string EventDescription { get; protected set; }
        public Guid Owner { get; protected set; }
        public Guid CalendarId { get; protected set; }
        public Boolean IsRemoved { get; protected set; }
        public DateTime StartDate { get; protected set; }
        public DateTime EndDate { get; protected set; }
        public DateTime CreateDate { get; protected set; }
        public DateTime? UpdateDate { get; protected set; }
        public bool AllDayEvent { get; protected set; }
        public TimeSpan? NotifyBefore { get; protected set; }
    }
}
