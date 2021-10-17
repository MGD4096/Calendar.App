using Calendar.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Application.Calendars.CreateNewCalendarCommand
{
    public class CreateNewCalendarCommand : CommandBase
    {
        public CreateNewCalendarCommand(string calendarName, string calendarDescription, Guid owner, bool isPublic, bool isRemoved, bool eventsCanBeModifiedBySubscriber)
        {
            CalendarName = calendarName;
            CalendarDescription = calendarDescription;
            Owner = owner;
            IsPublic = isPublic;
            IsRemoved = isRemoved;
            EventsCanBeModifiedBySubscriber = eventsCanBeModifiedBySubscriber;
        }

        public string CalendarName { get; set; }
        public string CalendarDescription { get; set; }
        public Guid Owner { get; set; }
        public Boolean IsPublic { get; set; }
        public Boolean IsRemoved { get; set; }
        public Boolean EventsCanBeModifiedBySubscriber { get; set; }
        

    }
}
