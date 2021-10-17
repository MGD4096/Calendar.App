using User.Application.Contracts;
using System.Threading.Tasks;

namespace User.Application.Configuration.Commands
{
    public interface ICommandsScheduler
    {
        Task EnqueueAsync(ICommand command);
    }
}