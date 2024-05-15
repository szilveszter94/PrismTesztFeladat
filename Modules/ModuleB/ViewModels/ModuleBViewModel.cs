using Core;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.ObjectModel;

namespace ModuleB.ViewModels;

public class ModuleBViewModel : BindableBase
{
    public DelegateCommand ChangeViewsCommand { get; }
    private readonly IModuleRegistry _moduleRegistry;
    private readonly IRegionManager _regionManager;
    private readonly ObservableCollection<string> _messages = new ();

    public ObservableCollection<string> Messages => _messages;

    public ModuleBViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, IModuleRegistry moduleRegistry)
    {
        _moduleRegistry = moduleRegistry;
        _regionManager = regionManager;
        ChangeViewsCommand = new DelegateCommand(ChangeViews);
        eventAggregator.GetEvent<MessageSentEvent>().Subscribe(HandleMessage);
    }

    private void HandleMessage(string message)
    {
        Messages.Add(message);
    }

    private void ChangeViews()
    {
        var baseType = _moduleRegistry.GetBaseModule()?.ToString();
        _regionManager.RequestNavigate(Regions.LeftRegion, baseType);
        _regionManager.RequestNavigate(Regions.RightRegion, baseType);
    }
    

}