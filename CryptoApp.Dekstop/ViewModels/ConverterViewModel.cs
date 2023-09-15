namespace CryptoApp.Dekstop.ViewModels
{
    public class ConverterViewModel : ViewModelBase
    {
        public ConverterViewModel()
        {
            CoinText = "1 bitcoin equals";
            CoinUsd = "36.93 Usd USA";
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
        private string _coinUsd;
        public string CoinUsd
        {
            get => _coinUsd;
            set
            {
                _coinUsd = value;
                OnPropertyChanged(nameof(CoinUsd));
            }
        }
    }
}
