using Core;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;

namespace PrismTesztFeladat.ViewModels;

public class MainWindowViewModel : BindableBase
{
    private string _title = "Prism Application";

    public string Title
    {
        get => _title;
        set => SetProperty(ref _title, value);
    }

    public MainWindowViewModel(IContainerExtension container, IRegionManager regionManager, IModuleRegistry moduleRegistry)
    {
        var baseType = moduleRegistry.GetBaseModule();
        regionManager.RegisterViewWithRegion(Regions.LeftRegion, baseType);
        regionManager.RegisterViewWithRegion(Regions.RightRegion, baseType);
    }
}

