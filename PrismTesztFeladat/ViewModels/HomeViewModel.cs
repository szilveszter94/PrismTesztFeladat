using Core;
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
            ShowModulesCommand = new DelegateCommand(ShowLeftAndRightRegion);
        }
        
        private void ShowLeftAndRightRegion()
        {
            _regionManager.RequestNavigate(Regions.LEFT_REGION, "ModuleAView");
            _regionManager.RequestNavigate(Regions.RIGHT_REGION, "ModuleBView");
        }
    }
}
