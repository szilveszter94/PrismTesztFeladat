using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using PrismTesztFeladat.Views;
using System.Windows;
using Core;

namespace PrismTesztFeladat;

public partial class App : PrismApplication
{
    private IContainerRegistry _containerRegistry;
    protected override Window CreateShell()
    {
        return Container.Resolve<MainWindow>();
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        _containerRegistry = containerRegistry;
        _containerRegistry.RegisterSingleton<IModuleRegistry>(() => new ModuleRegistry(typeof(HomeView)));
    }

    protected override IModuleCatalog CreateModuleCatalog()
    {
        var catalog =  new DirectoryModuleCatalog() { ModulePath = "./" };
        
        return catalog;
    }
}

