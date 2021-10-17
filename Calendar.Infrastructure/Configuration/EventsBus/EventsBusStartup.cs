using Autofac;
using Calendar.Infrastructure.Configuration;
using Domain.BuildingBlocks.Infrastructure.EventBus;
using Serilog;

namespace Calendar.Infrastructure.Configuration.EventsBus
{
    internal static class EventsBusStartup
    {
        internal static void Initialize(
            ILogger logger)
        {
            SubscribeToIntegrationEvents(logger);
        }

        private static void SubscribeToIntegrationEvents(ILogger logger)
        {
            var eventBus = CalendarCompositionRoot.BeginLifetimeScope().Resolve<IEventsBus>();

            //SubscribeToIntegrationEvent<SomeIntegratedEvents>(eventBus, logger);
        }

        private static void SubscribeToIntegrationEvent<T>(IEventsBus eventBus, ILogger logger)
            where T : IntegrationEvent
        {
            logger.Information("Subscribe to {@IntegrationEvent}", typeof(T).FullName);
            eventBus.Subscribe(
                new IntegrationEventGenericHandler<T>());
        }
    }
}