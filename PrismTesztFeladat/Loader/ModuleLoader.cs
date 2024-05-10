using System;
using System.Linq;
using System.Reflection;
using System.IO;
using Prism.Modularity;
using System.Collections.Generic;

namespace PrismTesztFeladat.Loader
{
    public class ModuleLoader
    {
        public IModuleCatalog CreateModuleCatalog(IEnumerable<string> _directories)
        {
            List<IModuleCatalogItem> components = new List<IModuleCatalogItem>();
            foreach (var dir in _directories)
            {
                var dirCatalog = new DirectoryModuleCatalog() { ModulePath = dir };
                dirCatalog.Initialize();
                components.AddRange(dirCatalog.Items);
            };

            var catalog = new ModuleCatalog();

            foreach (var com in components)
            {
                catalog.Items.Add(com);
            }

            return catalog;
        }

        public IEnumerable<string> SearchModules(IEnumerable<string> modulesNames, string folderName)
        {
            var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var parentDirectory = currentDirectory;
            while (!Directory.Exists(Path.Combine(parentDirectory, folderName)) && parentDirectory != null)
            {
                parentDirectory = Directory.GetParent(parentDirectory)?.FullName;
            }

            if (parentDirectory == null)
            {
                throw new DirectoryNotFoundException("Parent directory containing modules not found.");
            }

            return modulesNames.Select(s => Path.Combine(parentDirectory, "Modules", s, "bin", "Debug", "net6.0-windows"));
        }
    }
}
