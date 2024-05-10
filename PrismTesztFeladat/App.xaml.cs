using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using PrismTesztFeladat.Views;
using System.Windows;
using System.Linq;
using PrismTesztFeladat.Loader;
using System.IO;
using System;

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

        protected override IModuleCatalog CreateModuleCatalog()
        {
            var modulesToLoad = new string[] { "ModuleA", "ModuleB" };
            var folderName = "Modules";
            
            var moduleLoader = new ModuleLoader();
            var directories = moduleLoader.SearchModules(modulesToLoad, folderName);
            return moduleLoader.CreateModuleCatalog(directories);
        }
    }
}
