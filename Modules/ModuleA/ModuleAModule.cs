using Core;
using ModuleA.Views;
using Prism.Ioc;
using Prism.Modularity;

namespace ModuleA
{
    public class ModuleAModule : IModule
    {
        private readonly IViewRegistry _moduleRegistry;
        public ModuleAModule(IViewRegistry moduleRegistry)
        {
            _moduleRegistry = moduleRegistry;
        }
        
        public void OnInitialized(IContainerProvider containerProvider)
        {
            _moduleRegistry.AddView(Regions.LEFT_REGION, nameof(ModuleAView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ModuleAView>();
        }
    }
}
