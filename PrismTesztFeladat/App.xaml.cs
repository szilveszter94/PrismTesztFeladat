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

    protected override Window CreateShell() => Container.Resolve<MainWindow>();

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        _containerRegistry = containerRegistry;
        _containerRegistry.RegisterSingleton<IViewRegistry, ViewRegistry>();
        var registry = Container.Resolve<IViewRegistry>();
        registry.SetBaseView(typeof(HomeView));
    }

    protected override IModuleCatalog CreateModuleCatalog() => new DirectoryModuleCatalog() { ModulePath = "./" };
}

