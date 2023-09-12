using CryptoApp.Dekstop.NavigationServices;
using CryptoApp.Dekstop.ViewModels;
using CryptoApp.Dekstop.Views;
using System.Windows;

namespace CryptoApp.Dekstop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            _navigationStore = new NavigationStore();
        }
        private readonly NavigationStore _navigationStore;
        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = new HomeViewModel();
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };

            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
