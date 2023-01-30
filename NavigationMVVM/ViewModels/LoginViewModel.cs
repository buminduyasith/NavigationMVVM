using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NavigationMVVM.Stores;
using NavigationMVVM.Views;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NavigationMVVM.ViewModels
{
    public partial class LoginViewModel : ViewModelBase
    {
        [ObservableProperty]
        public string username;

        [ObservableProperty]
        public string password;

        private readonly NavigationStore navigationStore;


        public LoginViewModel()
        {
            navigationStore = Locator.Current.GetService<NavigationStore>();
        }

        [RelayCommand]
        public void Login()
        {
            
        }
    }

}
