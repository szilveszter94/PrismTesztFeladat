using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using PrismTesztFeladat.Views;
using System.Windows;

namespace PrismTesztFeladat
{
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new DirectoryModuleCatalog() { ModulePath = "./" };
        }
    }
}
