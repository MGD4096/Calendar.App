using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calendar.Api.Modules.Calendar
{
    public class CreateCalendarRequest
    {
        public string CalendarName { get; set; }
        public string CalendarDescription { get; set; }
        public Guid Owner { get; set; }
        public Boolean IsPublic { get; set; }
        public Boolean IsRemoved { get; set; }
        public Boolean EventsCanBeModifiedBySubscriber { get; set; }
    }
}
