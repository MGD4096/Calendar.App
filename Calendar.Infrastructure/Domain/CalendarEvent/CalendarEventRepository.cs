using Calendar.Domain.CalendarEvents;
using Calendar.Domain.Calendars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Infrastructure.Domain.CalendarEvent
{
    public class CalendarEventRepository : ICalendarEventRepository
    {
        private readonly CalendarContext _calendarContext;
        public CalendarEventRepository(CalendarContext calendarContext)
        {
            _calendarContext = calendarContext;
        }
        public async Task AddAsync(Calendar.Domain.CalendarEvents.CalendarEvent cEvent)
        {
            await _calendarContext.CalendarEvents.AddAsync(cEvent);

        }

        public async Task<Calendar.Domain.CalendarEvents.CalendarEvent> GetByIdAsync(CalendarEventId id)
        {
            return await _calendarContext.CalendarEvents.FindAsync(id);
        }
        public async Task<int> Commit()
        {
            return await _calendarContext.SaveChangesAsync();
        }
    }
}
