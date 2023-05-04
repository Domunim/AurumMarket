using AurumMarket.Domain.Models;
using AurumMarket.Domain.Services;
using AurumMarket.MetalPriceAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AurumMarket.WPF.ViewModels
{
    public class PreciousMetalsListingViewModel : ViewModelBase
    {
        private readonly AssetModelingServices _assetModeling;

        private AssetModel _gold;

        public AssetModel Gold
        {
            get { return _gold; }
            set
            {
                _gold = value;
                OnPropertyChanged(nameof(Gold));
            }
        }

        private AssetModel _silver;

        public AssetModel Silver
        {
            get { return _silver; }
            set
            {
                _silver = value;
                OnPropertyChanged(nameof(Silver));
            }
        }

        private AssetModel _platinum;

        public AssetModel Platinum
        {
            get { return _platinum; }
            set
            {
                _platinum = value;
                OnPropertyChanged(nameof(Platinum));
            }
        }

        private AssetModel _palladium;

        public AssetModel Palladium
        {
            get { return _palladium; }
            set
            {
                _palladium = value;
                OnPropertyChanged(nameof(Palladium));
            }
        }

        public PreciousMetalsListingViewModel(AssetModelingServices assetModeling) // parameter necessary?
        {
            _assetModeling = assetModeling; // necessary?
        }

        public static PreciousMetalsListingViewModel LoadMetalsViewModel() // the only reference, so must be left
        {
            // TODO - pass in an existing assetModeling? where to create it with global access?

            IMetalIndexServices metalIndexServices = new();

            AssetModelingServices.LoadAssetModelData();

            PreciousMetalsListingViewModel metalIndexViewModel = new();

            metalIndexViewModel.LoadAssets();

            return metalIndexViewModel;

        }


        private void LoadAssets() // wire up to global AssetModeling somehow or LoadMetalIndex again, but not null
        {           
            Gold = _assetModeling.Gold;   // now it is self-referring, no sense
            Silver = _assetModeling.Silver;
            Platinum = _assetModeling.Platinum;
            Palladium = _assetModeling.Palladium;
        }
    }
}
