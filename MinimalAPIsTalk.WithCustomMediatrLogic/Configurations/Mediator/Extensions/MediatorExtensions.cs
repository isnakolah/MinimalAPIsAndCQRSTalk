using System.Reflection;
using Microsoft.AspNetCore.Mvc.Routing;

namespace MinimalAPIsTalk.WithCustomMediatrLogic.Configurations.Mediator;

public static partial class Mediate
{
    public static WebApplication MapEndpoints(this WebApplication app, Type assemblyType)
    {
        var assemblyTypes = assemblyType.Assembly.GetExportedTypes();

        app.UseMediatorChecks( assemblyTypes);

        app.MapAllEndpointsFromAssembly(assemblyType.Assembly, assemblyTypes);
        
        return app;
    }


    private static WebApplication MapAllEndpointsFromAssembly(this WebApplication app, Assembly assembly, IEnumerable<Type> assemblyTypes)
    {
        var requestTypes = assemblyTypes
            .Where(t =>
            {
                if (t.GetCustomAttribute<HttpMethodAttribute>() is not {} attribute)
                {
                    return false;
                }

                var usage = attribute.GetType().GetCustomAttribute<AttributeUsageAttribute>();

                return usage?.ValidOn.HasFlag(AttributeTargets.Class) ?? false;
            });

        foreach (var requestType in requestTypes) 
        {
            var attribute = requestType.GetCustomAttribute<HttpMethodAttribute>();

            var template = attribute!.Template!;

            var httpMethod = attribute.HttpMethods.First();

            var responseType = requestType
                .GetInterfaces()
                .FirstOrDefault(i => i.IsGenericType && i.GetInterface(nameof(IBaseRequest)) != null)
                ?.GetGenericArguments()
                .LastOrDefault();

            if (responseType is null)
            {
                var withNoResponseTypeMethod = typeof(Mediate)
                    .GetMethods(BindingFlags.NonPublic | BindingFlags.Static)
                    .First(m => m.Name == nameof(MediateMethod) && m.GetGenericArguments().Length == 1)
                    .MakeGenericMethod(requestType);
                
                withNoResponseTypeMethod.Invoke(null, new object[] {app, template, httpMethod});

                continue;
            }
            
            var withResponseTypeMethod = typeof(Mediate)
                .GetMethods(BindingFlags.NonPublic | BindingFlags.Static)
                .First(m => m.Name == nameof(MediateMethod) && m.GetGenericArguments().Length == 2)
                .MakeGenericMethod(requestType, responseType);

            withResponseTypeMethod.Invoke(null, new object[] {app, template, httpMethod});
        }
        
        return app;
    }
}