﻿using AurumMarket.Domain.Models;
using AurumMarket.Domain.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumMarket.Domain.Services
{
    public class AssetModelingServices
    {

        private readonly IMetalIndexServices _metalIndexServices;
        
        private static AssetModel _gold;

        public AssetModel Gold
        {
            get { return _gold; }
            set
            {
                _gold = value;
            }
        }

        private static AssetModel _silver;

        public AssetModel Silver
        {
            get { return _silver; }
            set
            {
                _silver = value;
            }
        }

        private static AssetModel _platinum;

        public AssetModel Platinum
        {
            get { return _platinum; }
            set
            {
                _platinum = value;
            }
        }

        private static AssetModel _palladium;

        public AssetModel Palladium
        {
            get { return _palladium; }
            set
            {
                _palladium = value;
            }
        }
        public AssetModelingServices(IMetalIndexServices metalIndexServices)
        {
            _metalIndexServices = metalIndexServices;
        }

        public static AssetModelingServices LoadAssetModelData(IMetalIndexServices metalIndexServices)
        {
            AssetModelingServices updatedAssets = new(metalIndexServices);
            updatedAssets.LoadMetalIndex(metalIndexServices);
            return updatedAssets; // NOTE - refer to properties set below OR use updatedAssets in global context
        }



        private async Task LoadMetalIndex(IMetalIndexServices metalIndexServices)
        {
            if (AssetBank.Assets == null)
            {
                ResponseModel model = await _metalIndexServices.GetResponseFromAPI();

                Gold = _metalIndexServices.MakeAssetFromIndex(metalIndexServices.ConvertToMetalIndex(model), AssetType.Gold);
                Silver = _metalIndexServices.MakeAssetFromIndex(metalIndexServices.ConvertToMetalIndex(model), AssetType.Silver);
                Platinum = _metalIndexServices.MakeAssetFromIndex(metalIndexServices.ConvertToMetalIndex(model), AssetType.Platinum);
                Palladium = _metalIndexServices.MakeAssetFromIndex(metalIndexServices.ConvertToMetalIndex(model), AssetType.Palladium);

                AssetBank.Assets.Add(Gold);
                AssetBank.Assets.Add(Silver);
                AssetBank.Assets.Add(Platinum);
                AssetBank.Assets.Add(Palladium);
            }
        }

    }
}