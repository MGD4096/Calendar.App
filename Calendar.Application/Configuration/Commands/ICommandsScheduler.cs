using Calendar.Application.Contracts;
using System.Threading.Tasks;

namespace Calendar.Application.Configuration.Commands
{
    public interface ICommandsScheduler
    {
        Task EnqueueAsync(ICommand command);
    }
}