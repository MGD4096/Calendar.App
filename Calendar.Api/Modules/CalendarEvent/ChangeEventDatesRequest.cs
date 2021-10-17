using Calendar.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Api.Modules.CalendarEvent
{
    public class ChangeEventDatesRequest
    {
        public ChangeEventDatesRequest(DateTime startDate, DateTime endDate, Guid userId, Guid eventId)
        {
            this.startDate = startDate;
            this.endDate = endDate;
            UserId = userId;
            EventId = eventId;
        }

        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public Guid UserId { get; set; }
        public Guid EventId { get; set; }

    }
}
