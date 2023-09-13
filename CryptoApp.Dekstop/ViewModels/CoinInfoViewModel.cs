using CryptoApp.Dekstop.Commands;
using CryptoApp.Dekstop.NavigationServices;
using CryptoApp.Services.CoinGeckoServices;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CryptoApp.Dekstop.ViewModels
{
    public class CoinInfoViewModel : ViewModelBase
    {
        public CoinInfoViewModel(NavigationStore navigationStore,ICoinGeckoService coinGeckoService,string id)
        {
            Id = id;
            _navigationStore = navigationStore;
            _coinGeckoService = coinGeckoService;
            HomeCommand = new DelegateCommand(GoHome);
            GetCoin(id);
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

        private NavigationStore _navigationStore;
        private ICoinGeckoService _coinGeckoService;
        public ICommand HomeCommand { get; }
        private async Task GetCoin(string id)
        {
            Coin = new CoinViewModel(await _coinGeckoService.GetCoinByIdAsync(id));
        } 
        private void GoHome()
        {
            // TODO: Get HomeViewModel from a DI container
            _navigationStore.CurrentViewModel = new HomeViewModel(_navigationStore); 
        }
    }
}
