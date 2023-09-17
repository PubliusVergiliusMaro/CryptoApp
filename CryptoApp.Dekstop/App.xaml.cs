using CryptoApp.Dekstop.NavigationServices;
using CryptoApp.Dekstop.ViewModels;
using CryptoApp.Dekstop.Views;
using CryptoApp.Services.CoinCapServices;
using CryptoApp.Services.CoinGeckoServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace CryptoApp.Dekstop
{
    public partial class App : Application
    {
        public App()
        {
            IServiceCollection services = new ServiceCollection();

            NavigationService navigation = new NavigationService();
            MainViewModel main = new MainViewModel(navigation);
            ICoinCapService coinCapService = new CoinCapService();
            ICoinGeckoService coinGeckoService = new CoinGeckoService();
            coinGeckoService.ErrorOccurred += (sender, errorMessage) =>
            {
                // Display a message box with the error message.
                MessageBox.Show(errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            };
            HomeViewModel homeView = new HomeViewModel(navigation,coinGeckoService,coinCapService);
            navigation.CurrentViewModel = homeView;
            
            services.AddSingleton<ICoinGeckoService>(coinGeckoService);
            services.AddSingleton<ICoinCapService>(coinCapService);
            services.AddSingleton<NavigationService>(navigation);
            services.AddSingleton<MainViewModel>(main);
            services.AddSingleton<HomeViewModel>(homeView);
            services.AddSingleton<MainWindow>(provider => new MainWindow()
            {
                DataContext = main
            });
          
            services.AddSingleton<ConverterViewModel>();
            services.AddTransient<CoinInfoViewModel>();
           
            _serviceProvider = services.BuildServiceProvider();
            navigation.SetServiceProvider(_serviceProvider);
        }
        private readonly ServiceProvider _serviceProvider;
        protected override async void OnStartup(StartupEventArgs e)
        {
            var Main = _serviceProvider.GetRequiredService<MainWindow>();
            Main.Show();
            base.OnStartup(e);
        }
    }
}
