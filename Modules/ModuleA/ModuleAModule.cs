using System;
using Core;
using ModuleA.Views;
using Prism.Ioc;
using Prism.Modularity;

namespace ModuleA
{
    public class ModuleAModule : IModule
    {
        private readonly IModuleRegistry _moduleRegistry;
        public ModuleAModule(IModuleRegistry moduleRegistry)
        {
            _moduleRegistry = moduleRegistry;
        }
        
        public void OnInitialized(IContainerProvider containerProvider)
        {
            _moduleRegistry.AddModule(Regions.LeftRegion, nameof(ModuleAView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ModuleAView>();
        }
    }
}
