using CryptoApp.Dekstop.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CryptoApp.Dekstop.NavigationServices
{
    public class NavigationStore
    {
        private IServiceProvider _serviceProvider;
        public ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        public event Action CurrentViewModelChanged;
        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }

        public void SetServiceProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public void NavigateTo<TViewModel>() where TViewModel : ViewModelBase
        {
            CurrentViewModel = _serviceProvider.GetRequiredService<TViewModel>();
        }
    }
}
