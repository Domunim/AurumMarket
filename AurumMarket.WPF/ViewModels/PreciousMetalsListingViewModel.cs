using AurumMarket.Domain.Models;
using AurumMarket.Domain.Services;
using AurumMarket.MetalPriceAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;

namespace AurumMarket.WPF.ViewModels
{
    public class PreciousMetalsListingViewModel : ViewModelBase
    {
        private readonly IMetalIndexServices _metalIndexServices;

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

        public PreciousMetalsListingViewModel(IMetalIndexServices metalIndexServices)
        {
            _metalIndexServices = metalIndexServices;
        }

        public static PreciousMetalsListingViewModel LoadMetalIndexViewModel(IMetalIndexServices metalIndexServices)
        {
            PreciousMetalsListingViewModel metalIndexViewModel = new PreciousMetalsListingViewModel(metalIndexServices);
            metalIndexViewModel.LoadMetalIndex(metalIndexServices);
            return metalIndexViewModel;
        }

        private async Task LoadMetalIndex(IMetalIndexServices metalIndexServices)
        {           
            ResponseModel model = await _metalIndexServices.GetResponseFromAPI();

            Gold = _metalIndexServices.MakeAssetFromIndex(metalIndexServices.ConvertToMetalIndex(model), AssetType.Gold);
            Silver = _metalIndexServices.MakeAssetFromIndex(metalIndexServices.ConvertToMetalIndex(model), AssetType.Silver);
            Platinum = _metalIndexServices.MakeAssetFromIndex(metalIndexServices.ConvertToMetalIndex(model), AssetType.Platinum);
            Palladium = _metalIndexServices.MakeAssetFromIndex(metalIndexServices.ConvertToMetalIndex(model), AssetType.Palladium);
        }
    }
}
