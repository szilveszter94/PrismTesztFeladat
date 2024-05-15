using Core;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;

namespace ModuleA.ViewModels
{
    public class ModuleAViewModel : BindableBase
    {
        private IRegionManager _regionManager;
        private readonly IEventAggregator _eventAggregator;
        public DelegateCommand SendMessageCommand { get; }

        public bool CanSendMessage
        {
            get => _canSendMessage;
            set
            {
                SetProperty(ref _canSendMessage, value);
                SendMessageCommand.RaiseCanExecuteChanged();
            }
        }
        private bool _canSendMessage;

        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }
        private string _message;
        
        public ModuleAViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            _regionManager = regionManager;
            SendMessageCommand = new DelegateCommand(SendMessage, () => CanSendMessage);
            _eventAggregator = eventAggregator;
        }

        private void SendMessage()
        {
            if (!string.IsNullOrEmpty(Message))
            {
                _eventAggregator.GetEvent<MessageSentEvent>().Publish(Message);
                Message = string.Empty;
            }
        }
    }
}
