using CryptoApp.Models.DTOs;
using CryptoApp.Services.CoinCapServices;
using CryptoApp.Services.CoinGeckoServices;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Xml.Linq;

namespace CryptoApp.Dekstop.ViewModels
{
    public class ConverterViewModel : ViewModelBase
    {
        public ConverterViewModel(ICoinGeckoService coinGeckoService,ICoinCapService coinCapService)
        {
            _coinGeckoService = coinGeckoService;
            _coinCapService = coinCapService;
            ConvertFromCurrencies = new ObservableCollection<string>();
            ConvertToCurrencies = new ObservableCollection<string>();
            _allCoins = new List<CoinDTO>();
            Initialize();
        }
        private readonly ICoinGeckoService _coinGeckoService;
        private readonly ICoinCapService _coinCapService;
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
        //Convert FROM
        private CoinDTO _coinFrom;
        // Number
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
        // Selected Currency
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
        private decimal _convertToNumber;
        public decimal ConvertToNumber
        {
            get => _convertToNumber;
            set
            {
                _convertToNumber = value;
                //UpdateConvertedValue();
                OnPropertyChanged(nameof(ConvertToNumber));
            }
        }
        // Currencies
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

        // Default selected currencies
        private string _defaultFromCoin = "bitcoin";
        private string _defaultToCoin = "ethereum";
        // All Currencies
        private List<CoinDTO> _allCoins;
        
        // Update Result
        private async Task UpdateConvertedValue()
        {
             decimal coinFromUsd = _coinFrom.MarketData.CurrentPrice["usd"];
             decimal coinToUsd = _coinTo.MarketData.CurrentPrice["usd"];
             ConvertToNumber = ConvertFromNumber * (coinFromUsd/coinToUsd);
        }
        private async Task UpdateCoinFrom(string Name)
        {
            var coin = _allCoins.Where(c => c.Name == Name).FirstOrDefault();
            if (coin == null)
            {
                MessageBox.Show("Error");
                return;
            }
            _coinFrom = await _coinGeckoService.GetCoinByIdAsync(coin.Id);
            UpdateBasicInfo();
            UpdateConvertedValue();
        }
        private async Task UpdateCoinTo(string Name)
        {
            var coin = _allCoins.Where(c => c.Name == Name).FirstOrDefault();
            if (coin == null)
            {
                MessageBox.Show("Error");
                return;
            }
            _coinTo = await _coinGeckoService.GetCoinByIdAsync(coin.Id);
            UpdateConvertedValue();
        }

        private async Task Initialize()
        {
            _coinFrom = await _coinGeckoService.GetCoinByIdAsync(_defaultFromCoin);
            _coinTo = await _coinGeckoService.GetCoinByIdAsync(_defaultToCoin);
            _allCoins = await _coinCapService.GetAllCoinsAsync();

            foreach (CoinDTO coin in _allCoins)
            {
                ConvertFromCurrencies.Add(coin.Name);
                ConvertToCurrencies.Add(coin.Name);
            }
            ConvertFromNumber = 1.000M;
            ConvertFromCurrency = _coinFrom.Name;
            ConvertToCurrency = _coinTo.Name;
            UpdateBasicInfo();
        }
        private void UpdateBasicInfo()
        {
            CoinText = $"1 {_coinFrom.Name} equals";
            CoinToUsd = $"{_coinFrom.MarketData.CurrentPrice["usd"]} Usd USA";
            CoinChange = $"{_coinFrom.MarketData.PriceChange} ({_coinFrom.MarketData.PriceChangePercentage}%)";
            CoinChangeColor = _coinFrom.MarketData.PriceChangePercentage > 0 ? new SolidColorBrush(Colors.Green) : new SolidColorBrush(Colors.Red);
        }
    }
}
