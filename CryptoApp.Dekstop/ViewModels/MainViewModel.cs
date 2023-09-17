using CryptoApp.Dekstop.Commands;
using CryptoApp.Dekstop.NavigationServices;
using CryptoApp.Dekstop.Themes;
using System;
using System.Windows.Input;
using System.Windows.Media;

namespace CryptoApp.Dekstop.ViewModels
{
    /// <summary>
    /// ViewModel responsible for the MainWindow
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(NavigationService navigationStore)
        {
            _activeViewColor = new SolidColorBrush(Colors.YellowGreen);
            _defaultViewColor = new SolidColorBrush(Colors.White);
            HomeColor = _activeViewColor;
            ConverterColor = _defaultViewColor;
            _navigationStore = navigationStore;
            SelectConverterCommand = new DelegateCommand(OpenConverter);
            SelectHomeCommand = new DelegateCommand(OpenHome);
            ChangeThemeCommand = new DelegateCommand(ChangeTheme);
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            ThemeService.ChangeTheme(new Uri("/Themes/LightTheme.xaml", UriKind.Relative));
        }
        private static bool IsDarkTheme = false; 
        private readonly NavigationService _navigationStore;
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;
        /// <summary>
        /// Responsible for the navigation to ConverterView
        /// </summary>
        public ICommand SelectConverterCommand { get; }
        /// <summary>
        /// Responsible for the navigation to HomeView
        /// </summary>
        public ICommand SelectHomeCommand { get; }
        /// <summary>
        /// Responsible for the changing theme(light/dark) in the program
        /// </summary>
        public ICommand ChangeThemeCommand { get; }
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
        private void ChangeTheme()
        {
            if (!IsDarkTheme)
            {
                ThemeService.ChangeTheme(new Uri("/Themes/DarkTheme.xaml",UriKind.Relative));
                IsDarkTheme = true;
            }
            else
            {
                ThemeService.ChangeTheme(new Uri("/Themes/LightTheme.xaml", UriKind.Relative));
                IsDarkTheme = false;
            }
        }

        private void OpenConverter()
        {
            _navigationStore.NavigateTo<ConverterViewModel>();
            HomeColor = _defaultViewColor;
            ConverterColor = _activeViewColor;
        }
        private void OpenHome()
        {
            _navigationStore.NavigateTo<HomeViewModel>();
            HomeColor = _activeViewColor;
            ConverterColor = _defaultViewColor;
        }
        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
