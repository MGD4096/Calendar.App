﻿using System.Threading.Tasks;

namespace Domain.BuildingBlocks.Application.Outbox
{
    public interface IOutbox
    {
        void Add(OutboxMessage message);

        Task Save();
    }
}