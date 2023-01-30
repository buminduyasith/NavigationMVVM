using Avalonia.Controls;
using NavigationMVVM.ViewModels;
using Splat;

namespace NavigationMVVM.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = Locator.Current.GetService<MainWindowViewModel>();
            InitializeComponent();
        }
    }
}