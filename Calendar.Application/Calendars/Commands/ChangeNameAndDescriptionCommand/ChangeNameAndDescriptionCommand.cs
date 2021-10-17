using Calendar.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Application.Calendars.ChangeNameAndDescriptionCommand
{
    public class ChangeNameAndDescriptionCommand : CommandBase
    {
        public ChangeNameAndDescriptionCommand(string calendarName, string calendarDescription, Guid calendarId)
        {
            CalendarName = calendarName;
            CalendarDescription = calendarDescription;
            CalendarId = calendarId;
        }

        public string CalendarName { get; set; }
        public string CalendarDescription { get; set; }
        public Guid CalendarId { get; set; }

    }
}
