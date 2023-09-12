using CryptoApp.Models.DTOs;
using CryptoApp.Services.CoinGeckoServices;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.Dekstop.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly ICoinGeckoService _coinGeckoService;
        public HomeViewModel()
        {
            _coinGeckoService = new CoinGeckoService();
            _data = new StringBuilder();
            Data = "Test\n";
            LoadTestData();
        }
        private StringBuilder _data;
        public string Data
        {
            get => _data.ToString();
            set
            {
                _data = _data.Append(value);
                OnPropertyChanged(nameof(Data));
            }
        }
        private async Task LoadTestData()
        {
            var someCoin = await _coinGeckoService.GetCoinByIdAsync("bitcoin");
            Data = $"{someCoin.Id} {someCoin.CapRank}\n";
        }
    }
}
