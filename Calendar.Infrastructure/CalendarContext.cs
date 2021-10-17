using Domain.BuildingBlocks.Application.Outbox;
using Domain.BuildingBlocks.Infrastructure.InternalCommands;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Infrastructure
{
    public class CalendarContext:DbContext
    {
        public DbSet<Calendar.Domain.Calendars.Calendar> Calendar { get; set; }
        public DbSet<Calendar.Domain.CalendarEvents.CalendarEvent> CalendarEvents { get; set; }
        public DbSet<OutboxMessage> OutboxMessages { get; set; }

        public DbSet<InternalCommand> InternalCommands { get; set; }
        private readonly ILoggerFactory _loggerFactory;

        public CalendarContext(DbContextOptions options, ILoggerFactory loggerFactory)
           : base(options)
        {
            _loggerFactory = loggerFactory;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseLoggerFactory(_loggerFactory).EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }
}

