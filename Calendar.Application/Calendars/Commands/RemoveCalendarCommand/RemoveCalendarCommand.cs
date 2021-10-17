using Calendar.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Application.Calendars.RemoveCalendarCommand
{
    public class RemoveCalendarCommand : CommandBase
    {
        public RemoveCalendarCommand(Guid calendarId)
        {
            CalendarId = calendarId;
        }

        public Guid CalendarId { get; set; }

    }
}
