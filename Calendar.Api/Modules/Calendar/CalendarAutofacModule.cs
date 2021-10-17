using Autofac;
using Calendar.Application.Contracts;
using Calendar.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calendar.Api.Modules.Calendar
{
    public class CalendarAutofacModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CalendarModule>()
                .As<ICalendarModule>()
                .InstancePerLifetimeScope();
        }
    }
}
