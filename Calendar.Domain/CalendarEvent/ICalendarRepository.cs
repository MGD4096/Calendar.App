using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Domain.CalendarEvents
{
    public interface ICalendarEventRepository
    {
        Task AddAsync(CalendarEvent cEvent);

        Task<CalendarEvent> GetByIdAsync(CalendarEventId id);
        Task<int> Commit();
    }
}
