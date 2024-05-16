using Core;
using ModuleB.Views;
using Prism.Ioc;
using Prism.Modularity;

namespace ModuleB;

public class ModuleBModule : IModule
{
    private readonly IViewRegistry _moduleRegistry;

    public ModuleBModule(IViewRegistry moduleRegistry)
    {
        _moduleRegistry = moduleRegistry;
    }
    public void OnInitialized(IContainerProvider containerProvider)
    {
        _moduleRegistry.AddView(Regions.RIGHT_REGION, nameof(ModuleBView));
    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterForNavigation<ModuleBView>();
    }
}