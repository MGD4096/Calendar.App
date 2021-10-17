using Calendar.Application.Configuration.Commands;
using System.Reflection;

namespace Calendar.Infrastructure.Configuration
{
    internal static class Assemblies
    {
        public static readonly Assembly Application = typeof(InternalCommandBase).Assembly;
    }
}