using CryptoApp.Dekstop.Commands;
using CryptoApp.Dekstop.NavigationServices;
using CryptoApp.Models.DTOs;
using CryptoApp.Services.CoinGeckoServices;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CryptoApp.Dekstop.ViewModels
{
    public class CoinInfoViewModel : ViewModelBase
    {
        public CoinInfoViewModel(NavigationService navigationStore,ICoinGeckoService coinGeckoService,CoinDTO coin)
        {
            Id = coin.Id;
            Coin = new CoinViewModel(coin);
            _navigationStore = navigationStore;
            _coinGeckoService = coinGeckoService;
            HomeCommand = new DelegateCommand(GoHome);
        }

        private string _id;
        public string Id
        {
            get=> _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
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

        private NavigationService _navigationStore;
        private ICoinGeckoService _coinGeckoService;
        public ICommand HomeCommand { get; }
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
