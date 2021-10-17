using Calendar.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Application.CalendarEvents.AddCalendarEventCommand
{
    public class AddCalendarEventCommand : CommandBase
    {
        public AddCalendarEventCommand(string eventName, string eventDescription, Guid calendarId, Guid userId, bool isRemoved, bool allDayEvent, DateTime startDate, DateTime endDate, TimeSpan? notifyBefore)
        {
            EventName = eventName;
            EventDescription = eventDescription;
            CalendarId = calendarId;
            UserId = userId;
            IsRemoved = isRemoved;
            AllDayEvent = allDayEvent;
            StartDate = startDate;
            EndDate = endDate;
            NotifyBefore = notifyBefore;
        }

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
