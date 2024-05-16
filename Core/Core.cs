using Prism.Events;

namespace Core;

public static class Regions
{
    public const string LEFT_REGION = "LeftRegion";
    public const string RIGHT_REGION = "RightRegion";
}

public class MessageSentEvent : PubSubEvent<string>
{
}

public interface IViewRegistry
{
    Type? GetBaseView();
    string GetViewNameByRegionName(string regionName);
    void AddView(string regionName, string viewName);
    void SetBaseView(Type? baseType);
}

public class ViewRegisrty : IViewRegistry
{
    private readonly Dictionary<string, string> _viewTypes = new() {};
    private Type? _baseView;

    public void AddView(string regionName, string viewName)
    {
        _viewTypes[regionName] = viewName;
    }

    public void SetBaseView(Type? baseType) => _baseView = baseType;

    public string GetViewNameByRegionName(string regionName) => _viewTypes[regionName];

    public Type? GetBaseView() => _baseView;
}