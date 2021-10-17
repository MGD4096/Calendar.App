using System.Threading.Tasks;
using Domain.BuildingBlocks.Application.Outbox;

namespace Calendar.Infrastructure.Outbox
{
    public class OutboxAccessor : IOutbox
    {
        private readonly CalendarContext _calendarContext;

        internal OutboxAccessor(CalendarContext calendarContext)
        {
            _calendarContext = calendarContext;
        }

        public void Add(OutboxMessage message)
        {
            _calendarContext.OutboxMessages.Add(message);
        }

        public Task Save()
        {
            return Task.CompletedTask; // Save is done automatically using EF Core Change Tracking mechanism during SaveChanges.
        }
    }
}