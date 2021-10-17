using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Formatting.Compact;
using Hellang.Middleware.ProblemDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calendar.Api.Configuration.Extensions;
using Microsoft.AspNetCore.Http;
using Autofac;
using Calendar.Api.Configuration.ExecutionContext;
using Domain.BuildingBlocks.Infrastructure.Emails;
using Domain.BuildingBlocks.Application;
using Domain.BuildingBlocks.Domain;
using Calendar.Api.Configuration.Validation;
using Autofac.Extensions.DependencyInjection;
using Calendar.Api.Modules.Calendar;
using Calendar.Infrastructure.Configuration;
using User.Infrastructure.Configuration;

namespace Calendar.Api
{
    public class Startup
    {
        private const string CalendarConnectionString = "ConnectionStrings:calendarConnectionString";
        private static Serilog.ILogger _logger;
        private static Serilog.ILogger _loggerForApi;
        public Startup(IConfiguration configuration)
        {
            ConfigureLogger();
            //Configuration = configuration;

            Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                //  .AddJsonFile($"appsettings.{env.EnvironmentName}.json")
                //.AddUserSecrets<Startup>()
                .AddEnvironmentVariables("Calendar_")
                .Build();
            _loggerForApi.Information("Connection string:" + Configuration[CalendarConnectionString]);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerDocumentation();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IExecutionContextAccessor, ExecutionContextAccessor>();

            services.AddProblemDetails(x =>
            {
                x.Map<InvalidCommandException>(ex => new InvalidCommandProblemDetails(ex));
                x.Map<BusinessRuleValidationException>(ex => new BusinessRuleValidationExceptionProblemDetails(ex));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var container = app.ApplicationServices.GetAutofacRoot();
            InitializeModules(container);
            app.UseMiddleware<CorrelationMiddleware>();
            app.UseSwaggerDocumentation();
            if (env.IsDevelopment())
            {
                app.UseProblemDetails();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterModule(new CalendarAutofacModule());
        }
        private static void ConfigureLogger()
        {
            _logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console(
                    outputTemplate:
                    "[{Timestamp:HH:mm:ss} {Level:u3}] [{Module}] [{Context}] {Message:lj}{NewLine}{Exception}")
                .WriteTo.File(new CompactJsonFormatter(), "logs/logs.txt")
                .CreateLogger();

            _loggerForApi = _logger.ForContext("Module", "API");

            _loggerForApi.Information("Logger configured");
        }
        private void InitializeModules(ILifetimeScope container)
        {
            var httpContextAccessor = container.Resolve<IHttpContextAccessor>();
            var executionContextAccessor = new ExecutionContextAccessor(httpContextAccessor);
            var emailsConfiguration = new EmailsConfiguration(Configuration["EmailsConfiguration:FromEmail"]);
            CalendarStartup.Initialize(
                Configuration[CalendarConnectionString],
                executionContextAccessor,
                _logger,
                emailsConfiguration,
                null);
            UserStartup.Initialize(
                Configuration[CalendarConnectionString],
                executionContextAccessor,
                _logger,
                emailsConfiguration,
                null);
        }
    }
}
