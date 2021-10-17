using System;
using Autofac;
using Domain.BuildingBlocks.Application;
using Domain.BuildingBlocks.Infrastructure;
using Domain.BuildingBlocks.Infrastructure.Emails;
using Domain.BuildingBlocks.Infrastructure.EventBus;
using Serilog.Extensions.Logging;
using User.Infrastructure.Configuration.DataAccess;
using User.Infrastructure.Configuration.EventsBus;
using User.Infrastructure.Configuration.Logging;
using User.Infrastructure.Configuration.Mediation;
using User.Infrastructure.Configuration.Processing;
using User.Infrastructure.Configuration.Processing.Outbox;
using User.Infrastructure.Configuration.Quartz;
using ILogger = Serilog.ILogger;

namespace User.Infrastructure.Configuration
{
    public class UserStartup
    {
        private static IContainer _container;

        public static void Initialize(
            string connectionString,
            IExecutionContextAccessor executionContextAccessor,
            ILogger logger,
            EmailsConfiguration emailsConfiguration,
            IEventsBus eventsBus)
        {
            var moduleLogger = logger.ForContext("Module", "User");

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

            containerBuilder.RegisterModule(new LoggingModule(logger.ForContext("Module", "User")));

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

            UserCompositionRoot.SetContainer(_container);
        }
    }
}