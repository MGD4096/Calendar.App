using System;
using MediatR;

namespace Domain.BuildingBlocks.Domain
{
    public interface IDomainEvent : INotification
    {
        Guid Id { get; }

        DateTime OccurredOn { get; }
    }
}