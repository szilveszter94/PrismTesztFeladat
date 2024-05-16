using Core;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;

namespace ModuleA.ViewModels
{
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
            set
            {
                SetProperty(ref _message, value);
                System.Diagnostics.Debug.WriteLine(value);
                SendMessageCommand.RaiseCanExecuteChanged();
            }
        }

        private string _message;
        
        public ModuleAViewModel(IEventAggregator eventAggregator)
        {
            SendMessageCommand = new DelegateCommand(SendMessage, () => !string.IsNullOrEmpty(Message))
        .ObservesProperty(() => Message);
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
