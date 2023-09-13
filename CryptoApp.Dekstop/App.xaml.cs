using CryptoApp.Dekstop.NavigationServices;
using CryptoApp.Dekstop.ViewModels;
using CryptoApp.Dekstop.Views;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace CryptoApp.Dekstop
{
    public partial class App : Application
    {
        public App()
        {
            _navigationStore = new NavigationStore();
        }
      
        private readonly NavigationStore _navigationStore;
        protected override async void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = new HomeViewModel(_navigationStore);
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };

            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
