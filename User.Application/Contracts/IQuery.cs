using MediatR;

namespace User.Application.Contracts
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
    }
}