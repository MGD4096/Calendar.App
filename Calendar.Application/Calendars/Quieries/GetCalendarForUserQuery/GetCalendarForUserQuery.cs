using Calendar.Application.Configuration.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Application.Calendars.GetCalendarsForUserQuery
{
    public class GetCalendarsForUserQuery : QueryBase<List<CalendarDto>>
    {
        public GetCalendarsForUserQuery(Guid userId)
        {
            UserId= userId;
        }

        public Guid UserId { get; set; }
    }
}
