using Core;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;


namespace PrismTesztFeladat.ViewModels;

public class HomeViewModel : BindableBase
{
    private readonly IRegionManager _regionManager;
    private readonly IViewRegistry _moduleRegistry;
    public DelegateCommand ShowLeftAndRightRegionCommand { get; }

    public HomeViewModel(IRegionManager regionManager, IViewRegistry moduleRegistry)
    {
        _moduleRegistry = moduleRegistry;
        _regionManager = regionManager;
        ShowLeftAndRightRegionCommand = new DelegateCommand(ShowLeftAndRightRegion);
    }
    
    private void ShowLeftAndRightRegion()
    {
        var leftModule = _moduleRegistry.GetViewNameByRegionName(Regions.LEFT_REGION);
        var rightModule = _moduleRegistry.GetViewNameByRegionName(Regions.RIGHT_REGION);
        _regionManager.RequestNavigate(Regions.LEFT_REGION, leftModule);
        _regionManager.RequestNavigate(Regions.RIGHT_REGION, rightModule);
    }
}

