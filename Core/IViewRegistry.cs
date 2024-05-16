namespace Core;

public interface IViewRegistry
{
    Type? GetBaseView();
    string GetViewNameByRegionName(string regionName);
    void AddView(string regionName, string viewName);
    void SetBaseView(Type? baseType);
}
