using Domain.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Domain.Calendars
{
    public class CalendarId : TypedIdValueBase
    {
        public CalendarId(Guid value)
            : base(value)
        {
        }
    }
}
