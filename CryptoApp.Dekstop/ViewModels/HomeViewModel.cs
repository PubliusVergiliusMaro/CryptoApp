using CryptoApp.Dekstop.Commands;
using CryptoApp.Dekstop.NavigationServices;
using CryptoApp.Models.DTOs;
using CryptoApp.Services.CoinCapServices;
using CryptoApp.Services.CoinGeckoServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CryptoApp.Dekstop.ViewModels
{
    /// <summary>
    /// ViewModel responsible for the HomeView
    /// </summary>
    public class HomeViewModel : ViewModelBase
    {
        public HomeViewModel(NavigationService navigationStore, ICoinGeckoService coinGeckoService)
        {
            LoadingScreen = Visibility.Visible;
            _coinGeckoService = coinGeckoService;
            _navigationStore = navigationStore;
            Coins = new ObservableCollection<CoinBoxViewModel>();
            ClearSearchTextCommand = new DelegateCommand(ClearSearchText, CanClearSearchText);
            Initialize();
        }
        private readonly ICoinGeckoService _coinGeckoService;
        private readonly NavigationService _navigationStore;
        public ObservableCollection<CoinBoxViewModel> Coins { get; set; }
        private IList<CoinDTO> _allCoins { get; set; }
        private string _searchText;
        public string SearchText 
        { 
            get => _searchText;
            set 
            { 
                _searchText = value;
                SortCoins(value);
                OnPropertyChanged(nameof(SearchText));
            }
        }
        private Visibility _loadingScreen;
        public Visibility LoadingScreen
        {
            get => _loadingScreen;
            set
            {
                _loadingScreen = value;
                OnPropertyChanged(nameof(LoadingScreen));
            }
        }
        /// <summary>
        /// Responsible for clearing text in Search TextBox
        /// </summary>
        public ICommand ClearSearchTextCommand { get; }
      
        private List<CoinDTO> tempCoins = new List<CoinDTO>();
        private async Task Initialize()
        {
            List<CoinDTO> coins = await _coinGeckoService.GetAllCoinsAsync();
            _allCoins = new List<CoinDTO>();
            
            for (int i = 0; i < 250; i++)
                _allCoins.Add(coins[i]);

            foreach (CoinDTO coin in _allCoins)
                tempCoins.Add(coin);
            
            SortCoins("");
            LoadingScreen = Visibility.Hidden;
        }
        private async Task SortCoins(string keyword)
        {
            Coins.Clear();
            var temCoins = tempCoins.Where(c=>c.Name.ToLower().Contains(keyword.ToLower()));
            foreach(var coin in temCoins)
                Coins.Add(new CoinBoxViewModel(_navigationStore,_coinGeckoService, coin));
        }
        private void ClearSearchText() => SearchText = string.Empty;
        private bool CanClearSearchText() => !string.IsNullOrWhiteSpace(SearchText);
    }
}
