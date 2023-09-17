using CryptoApp.Dekstop.Commands;
using CryptoApp.Dekstop.NavigationServices;
using CryptoApp.Models.DTOs;
using CryptoApp.Services.CoinGeckoServices;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CryptoApp.Dekstop.ViewModels
{
    /// <summary>
    /// ViewModel for one button with onew coin info
    /// </summary>
    public class CoinBoxViewModel : ViewModelBase
    {
        public CoinBoxViewModel(NavigationService navigationStore, ICoinGeckoService coinGeckoService, CoinDTO coin)
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
            get => _symbol;
            set
            {
                _symbol = value;
                OnPropertyChanged(nameof(Symbol));
            }
        }
        private readonly NavigationService _navigationStore;
        private readonly ICoinGeckoService _coinGeckoService;
        /// <summary>
        /// The command that is invoked when clicking on a coin block. 
        /// </summary>
        public ICommand SelectCoinCommand { get; }
        private async void SelectCoin()
        {
            var coin = await _coinGeckoService.GetCoinByIdAsync(Id);
            _navigationStore.CurrentViewModel = new CoinInfoViewModel(_navigationStore, _coinGeckoService,coin);
        }
    }
}
