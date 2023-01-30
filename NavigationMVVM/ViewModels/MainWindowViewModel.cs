
using CommunityToolkit.Mvvm.ComponentModel;
using NavigationMVVM.Stores;
using NavigationMVVM.Views;
using Splat;

namespace NavigationMVVM.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        public string Greeting => "Welcome to Avalonia!";

        private readonly NavigationStore _navigationStore;

        [ObservableProperty]
        public ViewModelBase currentViewModel;

        public MainWindowViewModel()
        {
            _navigationStore = Locator.Current.GetService<NavigationStore>()!;

            CurrentViewModel = _navigationStore.CurrentViewModel;

            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}