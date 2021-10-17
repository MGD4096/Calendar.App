using Calendar.Domain.Calendars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Infrastructure.Domain.Calendars
{
    public class CalendarRepository : ICalendarRepository
    {
        private readonly CalendarContext _calendarContext;
        public CalendarRepository(CalendarContext calendarContext)
        {
            _calendarContext = calendarContext;
        }
        public async Task AddAsync(Calendar.Domain.Calendars.Calendar calendar)
        {
            await _calendarContext.Calendar.AddAsync(calendar);

        }

        public async Task<Calendar.Domain.Calendars.Calendar> GetByIdAsync(CalendarId id)
        {
            return await _calendarContext.Calendar.FindAsync(id);
        }
        public async Task<int> Commit()
        {
            return await _calendarContext.SaveChangesAsync();
        }
    }
}
