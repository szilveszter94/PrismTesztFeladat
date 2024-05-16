namespace Core;

public class ViewRegistry : IViewRegistry
{
    private readonly Dictionary<string, string> _viewTypes = new() {};
    private Type? _baseView;

    public void AddView(string regionName, string viewName) => _viewTypes[regionName] = viewName;

    public void SetBaseView(Type? baseType) => _baseView = baseType;

    public string GetViewNameByRegionName(string regionName) => _viewTypes[regionName];

    public Type? GetBaseView() => _baseView;
}