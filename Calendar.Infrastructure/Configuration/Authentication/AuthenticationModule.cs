using Autofac;

namespace Calendar.Infrastructure.Configuration.Authentication
{
    internal class AuthenticationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            ////builder.RegisterType<UserContext>()
            ////    .As<IUserContext>()
            ////    .InstancePerLifetimeScope();
        }
    }
}