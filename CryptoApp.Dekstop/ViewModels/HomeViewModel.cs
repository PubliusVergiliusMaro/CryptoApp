using CryptoApp.Dekstop.Commands;
using CryptoApp.Dekstop.NavigationServices;
using CryptoApp.Models.DTOs;
using CryptoApp.Services.CoinGeckoServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CryptoApp.Dekstop.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public HomeViewModel(NavigationStore navigationStore)
        {
            _coinGeckoService = new CoinGeckoService();
            _navigationStore = navigationStore;
            Coins = new ObservableCollection<CoinBoxViewModel>();
            ConverterCommand = new DelegateCommand(OpenConverter);
            LoadTestData();
        }

        private void OpenConverter()
        {
            _navigationStore.CurrentViewModel = new ConverterViewModel();
        }

        private readonly ICoinGeckoService _coinGeckoService;
        private readonly NavigationStore _navigationStore;
        public ObservableCollection<CoinBoxViewModel> Coins { get; set; }

        private async Task LoadTestData()
        {
            List<CoinDTO> _coins = await _coinGeckoService.GetAllCoinsAsync();
            for(int i=0; i< 300; i++)
            {
                Coins.Add(new CoinBoxViewModel(_coins[i]));
            }
        }
        public ICommand ConverterCommand { get; }
    }
}
