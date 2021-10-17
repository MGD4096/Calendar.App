using Calendar.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Api.Modules.CalendarEvent
{
    public class ChangeMainAttributesRequest
    {
        public ChangeMainAttributesRequest(string eventName, string eventDescription, Guid owner, Guid eventId)
        {
            EventName = eventName;
            EventDescription = eventDescription;
            Owner = owner;
            EventId = eventId;
        }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public Guid Owner { get; set; }
        public Guid EventId { get; set; }

    }
}
