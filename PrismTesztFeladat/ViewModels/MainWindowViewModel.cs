using System;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using PrismTesztFeladat.Views;

namespace PrismTesztFeladat.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        private IRegionManager _regionManager;

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public MainWindowViewModel(IContainerExtension container, IRegionManager regionManager)
        {
            _regionManager = regionManager;
            _regionManager.RegisterViewWithRegion("LeftRegion", typeof(HomeView));
            _regionManager.RegisterViewWithRegion("RightRegion", typeof(HomeView));
        }
    }
}
