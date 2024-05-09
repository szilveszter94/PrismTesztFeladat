using System;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace ModuleB.ViewModels;

public class ModuleBViewModel : BindableBase, INavigationAware
{
    public DelegateCommand ChangeViewsCommand { get; }
    private readonly IRegionManager _regionManager;
    public string? Message
    {
        get => _message;
        set => SetProperty(ref _message, value);
    }
    private string? _message;

    public ModuleBViewModel(IRegionManager regionManager)
    {
        _regionManager = regionManager;
        ChangeViewsCommand = new DelegateCommand(ChangeViews);
    }

    private void ChangeViews()
    {
        _regionManager.RequestNavigate("LeftRegion", "HomeView");
        _regionManager.RequestNavigate("RightRegion", "HomeView");
    }
    
    public void OnNavigatedTo(NavigationContext navigationContext)
    {
        if (navigationContext.Parameters.ContainsKey("message"))
        {
            Message = navigationContext.Parameters.GetValue<string>("message");
        }
    }

    public bool IsNavigationTarget(NavigationContext navigationContext)
    {
        return true;
    }

    public void OnNavigatedFrom(NavigationContext navigationContext)
    {
    }
}