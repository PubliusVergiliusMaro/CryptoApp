using CryptoApp.Dekstop.Commands;
using CryptoApp.Dekstop.NavigationServices;
using CryptoApp.Models.DTOs;
using CryptoApp.Services.CoinGeckoServices;
using System.Windows;
using System.Windows.Input;

namespace CryptoApp.Dekstop.ViewModels
{
    public class CoinBoxViewModel : ViewModelBase
    {
        public CoinBoxViewModel(NavigationStore navigationStore,ICoinGeckoService coinGeckoService,CoinDTO coin)
        {
            Id = coin.Id;
            Name = coin.Name;
            Symbol = coin.Symbol;
            _navigationStore = navigationStore;
            _coinGeckoService = coinGeckoService;
            SelectCoinCommand = new DelegateCommand(SelectCoin);
        }
        private string _id;
        public string Id
        {
            get => _id;
            set
            {
                _id = value; 
                OnPropertyChanged(nameof(Id));
            }
        }
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        private string _symbol;
        public string Symbol
        {
            get=> _symbol;
            set
            {
                _symbol = value;
                OnPropertyChanged(nameof(Symbol));
            }
        }
        private readonly NavigationStore _navigationStore;
        private readonly ICoinGeckoService _coinGeckoService;
        public ICommand SelectCoinCommand { get; }
        private void SelectCoin()
        {
            _navigationStore.CurrentViewModel = new CoinInfoViewModel(_navigationStore,_coinGeckoService,Id);
        }
    }
}
