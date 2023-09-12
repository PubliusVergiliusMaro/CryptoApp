using CryptoApp.Services.CoinGeckoServices;
using System.Windows;

namespace CryptoApp.Dekstop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Check if Coins are getting from API
            ICoinGeckoService coinGeckoService = new CoinGeckoService();
            var data = await coinGeckoService.GetAllCoinsAsync();

            var coin = await coinGeckoService.GetCoinByIdAsync("bitcoin");

            int a = 10;
        }
    }
}
