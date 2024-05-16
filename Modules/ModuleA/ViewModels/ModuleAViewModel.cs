using Core;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;

namespace ModuleA.ViewModels;

public class ModuleAViewModel : BindableBase
{
    private readonly IEventAggregator _eventAggregator;
    public DelegateCommand SendMessageCommand { get; }

    public bool CanSendMessage
    {
        get => _canSendMessage;
        set => SetProperty(ref _canSendMessage, value);
    }
    private bool _canSendMessage;

    public string Message
    {
        get => _message;
        set => SetProperty(ref _message, value);
    }
    private string _message;

    public ModuleAViewModel(IEventAggregator eventAggregator)
    {
        SendMessageCommand = new DelegateCommand(SendMessage, () => CanSendMessage && !string.IsNullOrEmpty(Message))
                            .ObservesProperty(() => Message)
                            .ObservesProperty(() => CanSendMessage);
        _eventAggregator = eventAggregator;
    }

    private void SendMessage()
    {
        if (string.IsNullOrEmpty(Message)) return;
        
        _eventAggregator.GetEvent<MessageSentEvent>().Publish(Message);
        Message = string.Empty;
        
    }
}
