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

            NavigationStore navigation = new NavigationStore();
            MainViewModel main = new MainViewModel(navigation);
            HomeViewModel homeView = new HomeViewModel(navigation);
            navigation.CurrentViewModel = homeView;
            
            services.AddSingleton<ICoinGeckoService,CoinGeckoService>();
            services.AddSingleton<ICoinCapService,CoinCapService>();
            services.AddSingleton<NavigationStore>(navigation);
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
