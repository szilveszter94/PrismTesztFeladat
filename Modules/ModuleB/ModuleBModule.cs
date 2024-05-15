using Core;
using ModuleB.Views;
using Prism.Ioc;
using Prism.Modularity;

namespace ModuleB;

public class ModuleBModule : IModule
{
    private readonly IModuleRegistry _moduleRegistry;

    public ModuleBModule(IModuleRegistry moduleRegistry)
    {
        _moduleRegistry = moduleRegistry;
    }
    public void OnInitialized(IContainerProvider containerProvider)
    {
    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterForNavigation<ModuleBView>();
    }
}