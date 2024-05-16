using Core;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;

namespace PrismTesztFeladat.ViewModels;

public class MainWindowViewModel : BindableBase
{
    public MainWindowViewModel(IContainerExtension container, IRegionManager regionManager, IViewRegistry moduleRegistry)
    {
        var baseType = moduleRegistry.GetBaseView();
        regionManager.RegisterViewWithRegion(Regions.LEFT_REGION, baseType);
        regionManager.RegisterViewWithRegion(Regions.RIGHT_REGION, baseType);
    }
}

