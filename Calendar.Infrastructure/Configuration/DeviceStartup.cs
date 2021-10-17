using System;
using Autofac;
using Calendar.Infrastructure.Configuration.Authentication;
using Calendar.Infrastructure.Configuration.DataAccess;
using Calendar.Infrastructure.Configuration.EventsBus;
using Calendar.Infrastructure.Configuration.Logging;
using Calendar.Infrastructure.Configuration.Mediation;
using Calendar.Infrastructure.Configuration.Processing;
using Calendar.Infrastructure.Configuration.Processing.Outbox;
using Calendar.Infrastructure.Configuration.Quartz;
using Domain.BuildingBlocks.Application;
using Domain.BuildingBlocks.Infrastructure;
using Domain.BuildingBlocks.Infrastructure.Emails;
using Domain.BuildingBlocks.Infrastructure.EventBus;
using Serilog.Extensions.Logging;
using ILogger = Serilog.ILogger;

namespace Calendar.Infrastructure.Configuration
{
    public class CalendarStartup
    {
        private static IContainer _container;

        public static void Initialize(
            string connectionString,
            IExecutionContextAccessor executionContextAccessor,
            ILogger logger,
            EmailsConfiguration emailsConfiguration,
            IEventsBus eventsBus)
        {
            var moduleLogger = logger.ForContext("Module", "Device");

            ConfigureCompositionRoot(
                connectionString,
                executionContextAccessor,
                moduleLogger,
                emailsConfiguration,
                eventsBus);

            QuartzStartup.Initialize(moduleLogger);
            EventsBusStartup.Initialize(moduleLogger);
        }

        public static void Stop()
        {
            QuartzStartup.StopQuartz();
        }

        private static void ConfigureCompositionRoot(
            string connectionString,
            IExecutionContextAccessor executionContextAccessor,
            ILogger logger,
            EmailsConfiguration emailsConfiguration,
            IEventsBus eventsBus)
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterModule(new LoggingModule(logger.ForContext("Module", "Device")));

            var loggerFactory = new SerilogLoggerFactory(logger);
            containerBuilder.RegisterModule(new DataAccessModule(connectionString, loggerFactory));
            containerBuilder.RegisterModule(new ProcessingModule());
            containerBuilder.RegisterModule(new EventsBusModule(eventsBus));
            containerBuilder.RegisterModule(new MediatorModule());
            //containerBuilder.RegisterModule(new AuthenticationModule());

            var domainNotificationsMap = new BiDictionary<string, Type>();
            //domainNotificationsMap.Add("MeetingCommentUnlikedNotification", typeof(MeetingCommentUnlikedNotification));
            containerBuilder.RegisterModule(new OutboxModule(domainNotificationsMap));

            //containerBuilder.RegisterModule(new EmailModule(emailsConfiguration));
            containerBuilder.RegisterModule(new QuartzModule());

            containerBuilder.RegisterInstance(executionContextAccessor);

            _container = containerBuilder.Build();

            CalendarCompositionRoot.SetContainer(_container);
        }
    }
}