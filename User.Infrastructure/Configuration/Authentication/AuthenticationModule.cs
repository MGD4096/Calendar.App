using Autofac;

namespace User.Infrastructure.Configuration.Authentication
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