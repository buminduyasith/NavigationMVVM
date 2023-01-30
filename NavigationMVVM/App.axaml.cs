using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.Hosting;
using NavigationMVVM.ViewModels;
using NavigationMVVM.Views;
using Splat.Microsoft.Extensions.DependencyInjection;
using Splat;
using System;
using Microsoft.Extensions.DependencyInjection;
using NavigationMVVM.Stores;

namespace NavigationMVVM
{
    public partial class App : Application
    {
        public IServiceProvider Container { get; private set; }
        public IHost host { get; set; }

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            host = Host.CreateDefaultBuilder()
              .ConfigureServices((_, services) =>
              {
                  services.UseMicrosoftDependencyResolver();
                  var resolver = Locator.CurrentMutable;
                  resolver.InitializeSplat();

                  ConfigureServices(services);
              })
              .Build();

            Container = host.Services;
            Container.UseMicrosoftDependencyResolver();

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {

                var navigationStore = Locator.Current.GetService<NavigationStore>()!;
                navigationStore.CurrentViewModel = new LoginViewModel();

                desktop.MainWindow = Locator.Current.GetService<MainWindow>();
            }

            base.OnFrameworkInitializationCompleted();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<MainWindow>();

            services.AddTransient<MainWindowViewModel>();
            services.AddSingleton<NavigationStore>();

        }
    }
}