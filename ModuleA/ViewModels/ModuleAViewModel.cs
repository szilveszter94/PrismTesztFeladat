using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace ModuleA.ViewModels
{
    public class ModuleAViewModel : BindableBase
    {
        private IRegionManager _regionManager;
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
        
        public ModuleAViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            SendMessageCommand = new DelegateCommand(SendMessage);
        }

        private void SendMessage()
        {
            var parameters = new NavigationParameters();
            parameters.Add("message", Message);
            _regionManager.RequestNavigate("RightRegion", "ModuleBView", parameters);
        }
    }
}
