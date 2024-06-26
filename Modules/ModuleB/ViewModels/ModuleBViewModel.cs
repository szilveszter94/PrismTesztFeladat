using Core;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.ObjectModel;

namespace ModuleB.ViewModels;

public class ModuleBViewModel : BindableBase
{
    private readonly IViewRegistry _moduleRegistry;
    private readonly IRegionManager _regionManager;
    
    public ObservableCollection<string> Messages => _messages;
    private readonly ObservableCollection<string> _messages = new();

    public DelegateCommand ChangeViewsCommand { get; }

    public ModuleBViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, IViewRegistry moduleRegistry)
    {
        _moduleRegistry = moduleRegistry;
        _regionManager = regionManager;
        ChangeViewsCommand = new DelegateCommand(ChangeViews);
        eventAggregator.GetEvent<MessageSentEvent>().Subscribe(HandleMessage);
    }

    private void HandleMessage(string message) => Messages.Add(message);

    private void ChangeViews()
    {
        var baseType = _moduleRegistry.GetBaseView()?.ToString();
        _regionManager.RequestNavigate(Regions.LEFT_REGION, baseType);
        _regionManager.RequestNavigate(Regions.RIGHT_REGION, baseType);
    }
}