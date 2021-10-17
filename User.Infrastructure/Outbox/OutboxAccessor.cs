using System.Threading.Tasks;
using Domain.BuildingBlocks.Application.Outbox;

namespace User.Infrastructure.Outbox
{
    public class OutboxAccessor : IOutbox
    {
        private readonly UserContext _userContext;

        internal OutboxAccessor(UserContext userContext)
        {
            _userContext = userContext;
        }

        public void Add(OutboxMessage message)
        {
            _userContext.OutboxMessages.Add(message);
        }

        public Task Save()
        {
            return Task.CompletedTask; // Save is done automatically using EF Core Change Tracking mechanism during SaveChanges.
        }
    }
}