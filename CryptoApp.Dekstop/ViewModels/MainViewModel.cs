using CryptoApp.Dekstop.Commands;
using CryptoApp.Dekstop.NavigationServices;
using System.Windows.Input;
using System.Windows.Media;

namespace CryptoApp.Dekstop.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;
        public ICommand SelectConverterCommand { get; }
        public ICommand SelectHomeCommand { get; }
        private SolidColorBrush _homeColor;
        public SolidColorBrush HomeColor 
        {
            get => _homeColor;
            set
            {
                _homeColor = value;
                OnPropertyChanged(nameof(HomeColor));
            }
        }
        private SolidColorBrush _converterColor;
        public SolidColorBrush ConverterColor 
        {
            get => _converterColor;
            set
            {
                _converterColor = value;
                OnPropertyChanged(nameof(ConverterColor));
            }
        }
        private readonly SolidColorBrush _activeViewColor;
        private readonly SolidColorBrush _defaultViewColor;
        public MainViewModel(NavigationStore navigationStore)
        {
            _activeViewColor = new SolidColorBrush(Colors.White);
            _defaultViewColor = new SolidColorBrush(Colors.YellowGreen);
            
            HomeColor = _activeViewColor;
            ConverterColor = _defaultViewColor;

            _navigationStore = navigationStore;
            SelectConverterCommand = new DelegateCommand(OpenConverter);
            SelectHomeCommand = new DelegateCommand(OpenHome);
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OpenConverter()
        {
            _navigationStore.NavigateTo<ConverterViewModel>();//.CurrentViewModel = new ConverterViewModel();
            HomeColor = _defaultViewColor;
            ConverterColor = _activeViewColor;
        }
        private void OpenHome()
        {
            _navigationStore.NavigateTo<HomeViewModel>();// = new HomeViewModel(_navigationStore);
            HomeColor = _activeViewColor;
            ConverterColor = _defaultViewColor;
        }
        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
