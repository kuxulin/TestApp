﻿using TestApp.Stores;
using TestApp.ViewModels;

namespace TestApp.Commands
{
    public class FindCurrencyNavigationCommand :BaseCommand
    {
        private readonly NavigationStore _navigationStore;

        public override bool CanExecute(object? parameter)
        {
            return _navigationStore is not null
                && _navigationStore.CurrentViewModel is not FindCurrencyViewModel
                && base.CanExecute(parameter);
        }

        public FindCurrencyNavigationCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            navigationStore.CurrentViewModelChanged += OnCurrentViewModelChange;
        }

        private void OnCurrentViewModelChange()
        {
            OnCanExecuteChanged();
        }

        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = new FindCurrencyViewModel(_navigationStore);
        }
    }
}
