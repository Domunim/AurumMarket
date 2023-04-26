using AurumMarket.Domain.Models;
using AurumMarket.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;

namespace AurumMarket.WPF.ViewModels
{
    public class MetalIndexViewModel : ViewModelBase
    {
        private readonly IMetalIndexServices _metalIndexServices;

        private MetalIndexModel _gold;

        public MetalIndexModel Gold
        {
            get { return _gold; }
            set
            {
                _gold = value;
                OnPropertyChanged(nameof(Gold));
            }
        }

        private MetalIndexModel _silver;

        public MetalIndexModel Silver
        {
            get { return _silver; }
            set
            {
                _silver = value;
                OnPropertyChanged(nameof(Silver));
            }
        }

        private MetalIndexModel _platinum;

        public MetalIndexModel Platinum
        {
            get { return _platinum; }
            set
            {
                _platinum = value;
                OnPropertyChanged(nameof(Platinum));
            }
        }

        private MetalIndexModel _palladium;

        public MetalIndexModel Palladium
        {
            get { return _palladium; }
            set
            {
                _palladium = value;
                OnPropertyChanged(nameof(Palladium));
            }
        }

        public MetalIndexViewModel(IMetalIndexServices metalIndexServices)
        {
            _metalIndexServices = metalIndexServices;
        }

        public static MetalIndexViewModel LoadMetalIndexViewModel(IMetalIndexServices metalIndexServices)
        {
            MetalIndexViewModel metalIndexViewModel = new MetalIndexViewModel(metalIndexServices);
            metalIndexViewModel.LoadMetalIndex();
            return metalIndexViewModel;
        }

        private async Task LoadMetalIndex()
        {
            await _metalIndexServices.GetMetalIndexResponse();
        }
    }
}
