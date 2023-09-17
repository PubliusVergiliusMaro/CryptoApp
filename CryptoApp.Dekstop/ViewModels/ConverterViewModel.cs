using CryptoApp.Models.DTOs;
using CryptoApp.Services.CoinCapServices;
using CryptoApp.Services.CoinGeckoServices;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace CryptoApp.Dekstop.ViewModels
{
    /// <summary>
    /// ViewModel responsible for the operation of the converter
    /// </summary>
    public class ConverterViewModel : ViewModelBase
    {
        public ConverterViewModel(ICoinCapService coinCapService)
        {
            LoadingScreen = Visibility.Visible;
            _coinCapService = coinCapService;
            ConvertFromCurrencies = new ObservableCollection<string>();
            ConvertToCurrencies = new ObservableCollection<string>();
            _allCoins = new List<CoinDTO>();
            Initialize();
        }
        private string _coinText;
        public string CoinText
        {
            get => _coinText;
            set
            {
                _coinText = value;
                OnPropertyChanged(nameof(CoinText));
            }
        }
        private string _coinToUsd;
        public string CoinToUsd
        {
            get => _coinToUsd;
            set
            {
                _coinToUsd = value;
                OnPropertyChanged(nameof(CoinToUsd));
            }
        }
        private string _coinChange;
        public string CoinChange
        {
            get => _coinChange;
            set
            {
                _coinChange = value;

                OnPropertyChanged(nameof(CoinChange));
            }
        }
        private SolidColorBrush _coinChangeColor;
        public SolidColorBrush CoinChangeColor
        {
            get => _coinChangeColor;
            set
            {
                _coinChangeColor = value;
                OnPropertyChanged(nameof(CoinChangeColor));
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
        //Convert FROM
        private CoinDTO _coinFrom;
        // Value
        private decimal _convertFromNumber;
        public decimal ConvertFromNumber
        {
            get => _convertFromNumber;
            set
            {
                _convertFromNumber = value;
                UpdateConvertedValue();
                OnPropertyChanged(nameof(ConvertFromNumber));
            }
        }
        // Currencies
        public ObservableCollection<string> ConvertFromCurrencies { get; set; }
        // Selected currency that we will convert
        private string _convertFromCurrency;
        public string ConvertFromCurrency
        {
            get => _convertFromCurrency;
            set
            {
                _convertFromCurrency = value;
                UpdateCoinFrom(value);
                OnPropertyChanged(nameof(ConvertFromCurrency));
            }
        }

        //Convert TO
        private CoinDTO _coinTo;
        // Number
        private decimal? _convertToNumber;
        public decimal? ConvertToNumber
        {
            get => _convertToNumber;
            set
            {
                _convertToNumber = value;
                //UpdateConvertedValue();
                OnPropertyChanged(nameof(ConvertToNumber));
            }
        }
        // Currencie
        public ObservableCollection<string> ConvertToCurrencies { get; set; }
        // Currency
        private string _convertToCurrency;
        public string ConvertToCurrency
        {
            get => _convertToCurrency;
            set
            {
                _convertToCurrency = value;
                UpdateCoinTo(value);
                OnPropertyChanged(nameof(ConvertToCurrency));
            }
        }
        /// <summary>
        /// All Currencies
        /// </summary>
        private static List<CoinDTO> _allCoins;
        private readonly ICoinCapService _coinCapService;
        /// <summary>
        /// Update convertation result
        /// </summary>
        /// <returns></returns>
        private async Task UpdateConvertedValue() => ConvertToNumber = ConvertFromNumber * (_coinFrom.PriceUsd/_coinTo.PriceUsd);
        /// <summary>
        /// Update Info about coin that we want to convert
        /// </summary>
        /// <param name="Name">Name of coin</param>
        /// <returns></returns>
        private async Task UpdateCoinFrom(string Name)
        {
            _coinFrom = await GetCoinByName(Name);
            UpdateBasicInfo();
            UpdateConvertedValue();
        }
        private async Task UpdateCoinTo(string Name)
        {
            _coinTo = await GetCoinByName(Name);
            UpdateConvertedValue();
        }
        private async Task<CoinDTO> GetCoinByName(string Name)
        {
            var coin = _allCoins.Where(c => c.Name == Name).FirstOrDefault();
            if (coin == null)
            {
                MessageBox.Show("Didn`t find such coin");
                return null;
            }
            var tempCoin = await _coinCapService.GetCoinByIdAsync(coin.Id);
            return tempCoin;
        }
        private async Task Initialize()
        {
            _allCoins = await _coinCapService.GetAllCoinsAsync();//new List<CoinDTO>();
            _coinFrom = await _coinCapService.GetCoinByIdAsync("bitcoin");
            _coinTo = await _coinCapService.GetCoinByIdAsync("ethereum");

            foreach (CoinDTO coin in _allCoins)
            {
                ConvertFromCurrencies.Add(coin.Name);
                ConvertToCurrencies.Add(coin.Name);
            }
            ConvertFromNumber = 1.000M;
            ConvertFromCurrency = _coinFrom.Name;
            ConvertToCurrency = _coinTo.Name;
            UpdateBasicInfo();
            LoadingScreen = Visibility.Hidden;
        }
        private void UpdateBasicInfo()
        {
            CoinText = $"One {_coinFrom.Name} equals";
            CoinToUsd = $"{_coinFrom.PriceUsd} USD USA";
            CoinChange = $"{_coinFrom.ChangePercent24Hr}%";
            CoinChangeColor = _coinFrom.ChangePercent24Hr > 0 ? new SolidColorBrush(Colors.Green) : new SolidColorBrush(Colors.Red);
        }
    }
}
