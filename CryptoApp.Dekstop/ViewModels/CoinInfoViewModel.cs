using CryptoApp.Dekstop.Commands;
using CryptoApp.Dekstop.NavigationServices;
using CryptoApp.Models.DTOs;
using CryptoApp.Services.CoinGeckoServices;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace CryptoApp.Dekstop.ViewModels
{
    public class CoinInfoViewModel : ViewModelBase
    {
        public CoinInfoViewModel(NavigationService navigationStore,ICoinGeckoService coinGeckoService,CoinDTO coin)
        {
            Coin = new CoinViewModel(coin);
            Id = Coin.Id ?? "No data";
            Symbol = Coin.Symbol ?? "No data";
            Name = Coin.Name ?? "No data";
            CapRank = Coin.CapRank?.ToString() ?? "No data";
            PriceChange14d = Coin.PriceChange14d?.ToString() ?? "No data";
            PriceChangeColor = Coin.PriceChange14d > 0 ? new SolidColorBrush(Colors.Green) : new SolidColorBrush(Colors.Red);
            LastUpdated = Coin.LastUpdated?.ToString() ?? "No data";
            HomePage = Coin.Homepages?.FirstOrDefault() ?? "No data";
            CurrentPrice = Coin.CurrentPrice?["usd"]?.ToString() ?? "No data";
            TotalVolume = Coin.TotalVolume?["usd"]?.ToString() ?? "No data";
            _navigationStore = navigationStore;
            _coinGeckoService = coinGeckoService;
            HomeCommand = new DelegateCommand(GoHome);
            OpenBrowserCommand = new DelegateCommand(OpenBrowser,CanOpenBrowser);
        }

        private bool CanOpenBrowser() => !string.IsNullOrWhiteSpace(HomePage);

        private void OpenBrowser()
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = HomePage,
                UseShellExecute = true
            }) ;
        }

        private CoinViewModel _coin;
        public CoinViewModel Coin
        {
            get => _coin;
            set
            {
                _coin = value;
                OnPropertyChanged(nameof(Coin));
            }
        }
        public string Id { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string CapRank { get; set; }
        public string PriceChange14d { get; set; }
        public SolidColorBrush PriceChangeColor { get; set; }
        public string LastUpdated { get; set; }
        public string HomePage { get; set; }
        public string CurrentPrice { get; set; }
        public string TotalVolume { get; set; }

        private NavigationService _navigationStore;
        private ICoinGeckoService _coinGeckoService;
        public ICommand HomeCommand { get; }
        public ICommand OpenBrowserCommand { get; }
        //private async Task GetCoin(string id)
        //{
        //    var coin = await _coinGeckoService.GetCoinByIdAsync(id);
        //    Coin = new CoinViewModel(coin);
        //} 
        private void GoHome()
        {
            _navigationStore.NavigateTo<HomeViewModel>(); 
        }
    }
}
