using System;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace PrismTesztFeladat.ViewModels
{
    public class HomeViewModel : BindableBase
    {
        private IRegionManager _regionManager;
        public DelegateCommand ShowModulesCommand { get; }

        public HomeViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            ShowModulesCommand = new DelegateCommand(ShowModules);
        }
        
        private void ShowModules()
        {
            _regionManager.RequestNavigate("LeftRegion", "ModuleAView");
            _regionManager.RequestNavigate("RightRegion", "ModuleBView");
        }
    }
}
