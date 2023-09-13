using CryptoApp.Dekstop.Commands;
using CryptoApp.Models.DTOs;
using System.Windows;
using System.Windows.Input;

namespace CryptoApp.Dekstop.ViewModels
{
    public class CoinBoxViewModel : ViewModelBase
    {
        public CoinBoxViewModel(CoinDTO coin)
        {
            Id = coin.Id;
            Name = coin.Name;
            Symbol = coin.Symbol;
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
        public ICommand SelectCoinCommand { get; }
        private void SelectCoin()
        {
            MessageBox.Show("Test");
        }
    }
}
