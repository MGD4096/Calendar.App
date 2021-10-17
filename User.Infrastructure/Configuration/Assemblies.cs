using System.Reflection;
using User.Application.Configuration.Commands;

namespace User.Infrastructure.Configuration
{
    internal static class Assemblies
    {
        public static readonly Assembly Application = typeof(InternalCommandBase).Assembly;
    }
}