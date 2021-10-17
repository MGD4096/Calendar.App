using MediatR;

namespace Calendar.Application.Contracts
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
    }
}