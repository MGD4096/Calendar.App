using Autofac;
using Calendar.Application.Contracts;
using Calendar.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.Application.Contracts;
using User.Infrastructure;

namespace Calendar.Api.Modules.User
{
    public class UserAutofacModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserModule>()
                .As<IUserModule>()
                .InstancePerLifetimeScope();
        }
    }
}
