using ModuleA;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using PrismTesztFeladat.Views;
using System.Windows;

namespace PrismTesztFeladat
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ModuleAModule>();
        }
    }
}
