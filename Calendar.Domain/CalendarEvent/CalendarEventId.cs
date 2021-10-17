using Domain.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Domain.CalendarEvents
{
    public class CalendarEventId : TypedIdValueBase
    {
        public CalendarEventId(Guid value)
            : base(value)
        {
        }
    }
}
