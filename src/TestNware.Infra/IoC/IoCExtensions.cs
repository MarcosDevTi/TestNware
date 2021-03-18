using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;
using TestNware.Domain.Contracts;
using TestNware.Infra.Handlers;

namespace TestNware.Infra.IoC
{
    public static class IoCExtensions
    {
        public static void AddCqrs(this IServiceCollection services, Func<AssemblyName, bool> filter = null) =>
            AddCqrs<PostQueryHandler>(services, filter);

        public static void AddCqrs<T>(this IServiceCollection services, Func<AssemblyName, bool> filter = null)
        {
            var handlers = new[] { typeof(ICommandHandlerAsync<>), typeof(ICommandHandler<>), typeof(IQueryHandler<,>) };

            static bool FilterTrue(AssemblyName a) => true;
            var target = typeof(T).Assembly;

            var assemblies = target.GetReferencedAssemblies()
                .Where(filter ?? FilterTrue)
                .Select(Assembly.Load)
                .ToList();
            assemblies.Add(target);

            var types = from t in assemblies.SelectMany(a => a.GetExportedTypes())
                        from i in t.GetInterfaces()
                        where i.IsConstructedGenericType
                        && handlers.Contains(i.GetGenericTypeDefinition())
                        select new { i, t };

            foreach (var type in types) services.AddScoped(type.i, type.t);

            services.AddScoped<IProcessor, Processor>();
        }
    }
}
