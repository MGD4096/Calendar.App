using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Domain.Calendars
{
    public interface ICalendarRepository
    {
        Task AddAsync(Calendar calendar);

        Task<Calendar> GetByIdAsync(CalendarId id);
        Task<int> Commit();
    }
}
