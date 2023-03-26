using System.Reflection;

namespace MinimalAPIsTalk.WithCustomMediatrLogic;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        ApplyMappingsFromAssembly(AppDomain.CurrentDomain.GetAssemblies());
    }

    private void ApplyMappingsFromAssembly(Assembly[] assemblies)
    {
        var types = assemblies
            .SelectMany(x => x.GetExportedTypes())
            .Where(t => t
                .GetInterfaces()
                .Any(i => i.IsGenericType && i.GetInterfaces().Contains(typeof(IBaseDTO))));

        foreach (var type in types)
        {
            var instance = Activator.CreateInstance(type);

            var iMapMethodInfo = type.GetMethod("Mapping");

            iMapMethodInfo?.Invoke(instance, new object?[] { this });
        }
    }
}