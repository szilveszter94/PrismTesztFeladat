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
    private readonly IRegionManager _regionManager;
    public ObservableCollection<string> Messages
    {
        get { return _messages; }
    }
    private ObservableCollection<string> _messages = new ObservableCollection<string>();

    public ModuleBViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
    {
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
        _regionManager.RequestNavigate(Regions.LEFT_REGION, "HomeView");
        _regionManager.RequestNavigate(Regions.RIGHT_REGION, "HomeView");
    }
    

}