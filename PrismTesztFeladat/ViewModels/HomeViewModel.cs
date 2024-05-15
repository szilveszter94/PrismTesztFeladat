using Core;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;


namespace PrismTesztFeladat.ViewModels;

public class HomeViewModel : BindableBase
{
    private readonly IRegionManager _regionManager;
    private readonly IModuleRegistry _moduleRegistry;
    public DelegateCommand ShowLeftAndRightRegionCommand { get; }

    public HomeViewModel(IRegionManager regionManager, IModuleRegistry moduleRegistry)
    {
        _moduleRegistry = moduleRegistry;
        _regionManager = regionManager;
        ShowLeftAndRightRegionCommand = new DelegateCommand(ShowLeftAndRightRegion);
    }
    
    private void ShowLeftAndRightRegion()
    {
        var leftModule = _moduleRegistry.GetModuleTypeByRegion(Regions.LeftRegion);
        var rightModule = _moduleRegistry.GetModuleTypeByRegion(Regions.RightRegion);
        _regionManager.RequestNavigate(Regions.LeftRegion, leftModule);
        _regionManager.RequestNavigate(Regions.RightRegion, rightModule);
    }
}

