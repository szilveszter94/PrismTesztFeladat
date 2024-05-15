using Prism.Events;

namespace Core;

public static class Regions
{
    public const string LeftRegion = "LeftRegion";
    public const string RightRegion = "RightRegion";
}

public class MessageSentEvent : PubSubEvent<string>
{
}

public interface IModuleRegistry
{
    public Type? GetBaseModule();
    public string GetModuleTypeByRegion(string regionName);
}

public class ModuleRegistry : IModuleRegistry
{
    private readonly Dictionary<string, string> _moduleTypes =
        new() { { Regions.LeftRegion, "ModuleAView" }, { Regions.RightRegion, "ModuleBView" } };

    private Type? _baseType;

    public ModuleRegistry(Type moduleType)
    {
        _baseType = moduleType;
    }

    public string GetModuleTypeByRegion(string regionName)
    {
        return _moduleTypes[regionName];
    }

    public Type? GetBaseModule()
    {
        return _baseType;
    }
}