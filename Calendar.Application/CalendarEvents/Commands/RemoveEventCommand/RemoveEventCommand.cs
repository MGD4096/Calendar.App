using Calendar.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Application.CalendarEvents.RemoveEventCommand
{
    public class RemoveEventCommand : CommandBase
    {
        public RemoveEventCommand(Guid eventId, Guid userId)
        {
            EventId = eventId;
            UserId = userId;
        }

        public Guid EventId { get; set; }
        public Guid UserId { get; set; }
    }
}
