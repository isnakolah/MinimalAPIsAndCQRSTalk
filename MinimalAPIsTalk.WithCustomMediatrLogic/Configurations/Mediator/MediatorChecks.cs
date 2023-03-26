using System.Reflection;

namespace MinimalAPIsTalk.WithCustomMediatrLogic.Configurations.Mediator;

public static partial class Mediate
{
    private static WebApplication UseMediatorChecks(this WebApplication app, Type[] assemblyTypes)
    {
        var types = assemblyTypes
            .Where(t => t.GetInterfaces().Contains(typeof(IBaseRequest)))
            .Where(t => !t.IsInterface)
            .Where(t => 
                t.GetCustomAttribute<HttpGetAttribute>() == null &&
                t.GetCustomAttribute<HttpPostAttribute>() == null &&
                t.GetCustomAttribute<HttpPutAttribute>() == null  &&
                t.GetCustomAttribute<HttpDeleteAttribute>() == null)
            .ToArray();

        if (types.Any())
        {
            throw new Exception($"The following types are missing http method attributes: {string.Join(", ", types.Select(t => t.Name))}");
        }

        return app;
    }
}