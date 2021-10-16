using System;
using System.Threading.Tasks;

namespace Calendar.Application.Contracts
{
    public interface ICalendarModule
    {
        Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command);

        Task ExecuteCommandAsync(ICommand command);

        Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query);
    }
}
