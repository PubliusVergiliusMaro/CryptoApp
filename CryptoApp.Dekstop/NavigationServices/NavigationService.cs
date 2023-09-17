using CryptoApp.Dekstop.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CryptoApp.Dekstop.NavigationServices
{
    /// <summary>
    /// Service for navigation
    /// </summary>
    public class NavigationService
    {
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel; 
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }
        private IServiceProvider _serviceProvider;
        public ViewModelBase _currentViewModel;
        public event Action CurrentViewModelChanged;
        private void OnCurrentViewModelChanged() => CurrentViewModelChanged?.Invoke();
        public void SetServiceProvider(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;
        public void NavigateTo<TViewModel>() where TViewModel : ViewModelBase => CurrentViewModel = _serviceProvider.GetRequiredService<TViewModel>();
    }
}
