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
    public class PreciousMetalsListingViewModel : ViewModelBase
    {
        private readonly IMetalIndexServices _metalIndexServices;

        private PreciousMetalsListingViewModel _gold;

        public PreciousMetalsListingViewModel Gold
        {
            get { return _gold; }
            set
            {
                _gold = value;
                OnPropertyChanged(nameof(Gold));
            }
        }

        private PreciousMetalsListingViewModel _silver;

        public PreciousMetalsListingViewModel Silver
        {
            get { return _silver; }
            set
            {
                _silver = value;
                OnPropertyChanged(nameof(Silver));
            }
        }

        private PreciousMetalsListingViewModel _platinum;

        public PreciousMetalsListingViewModel Platinum
        {
            get { return _platinum; }
            set
            {
                _platinum = value;
                OnPropertyChanged(nameof(Platinum));
            }
        }

        private PreciousMetalsListingViewModel _palladium;

        public PreciousMetalsListingViewModel Palladium
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
            metalIndexViewModel.LoadMetalIndex();


            //MakeAssetFromIndex(ConvertToMetalIndex(modelFromAPI), AssetType.Gold);
            //MakeAssetFromIndex(ConvertToMetalIndex(modelFromAPI), AssetType.Silver);
            //MakeAssetFromIndex(ConvertToMetalIndex(modelFromAPI), AssetType.Platinum);
            //MakeAssetFromIndex(ConvertToMetalIndex(modelFromAPI), AssetType.Palladium);


            return metalIndexViewModel;
        }

        private async Task LoadMetalIndex()
        {
            await _metalIndexServices.GetResponseFromAPI();
        }

    }
}
