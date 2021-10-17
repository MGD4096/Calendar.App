using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calendar.Api.Modules.CalendarEvent
{
    public class CreateCalendarEventRequest
    {
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public Guid CalendarId { get; set; }
        public Guid UserId { get; set; }
        public Boolean IsRemoved { get; set; }
        public Boolean AllDayEvent { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan? NotifyBefore { get; set; }
    }
}
