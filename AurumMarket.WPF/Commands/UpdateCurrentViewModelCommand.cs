using AurumMarket.MetalPriceAPI.Services;
using AurumMarket.WPF.State.Navigators;
using AurumMarket.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AurumMarket.WPF.Commands
{
    class UpdateCurrentViewModelCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private INavigator _navigator;

        public UpdateCurrentViewModelCommand(INavigator navigator)
        {
            _navigator = navigator;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter is ViewType)
            {
                ViewType viewType = (ViewType)parameter;
               
                switch (viewType)
                {
                    case ViewType.Home:
                        _navigator.CurrentViewModel = new HomeViewModel(PreciousMetalsListingViewModel.LoadMetalsViewModel());
                        break;

                    case ViewType.Assets:
                        _navigator.CurrentViewModel = new YourAssetsViewModel();
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
