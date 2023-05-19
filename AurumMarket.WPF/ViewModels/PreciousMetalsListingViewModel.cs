﻿using AurumMarket.Domain.Models;
using AurumMarket.Domain.Services;
using AurumMarket.Domain.Static;
using AurumMarket.MetalPriceAPI.Services;
using Azure.Identity;
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

        public PreciousMetalsListingViewModel() {}

        public static PreciousMetalsListingViewModel LoadMetalsViewModel()
        {
            PreciousMetalsListingViewModel metalIndexViewModel = new();

            metalIndexViewModel.UpdateMetalsViewModel();

            return metalIndexViewModel;
        }

        public async Task UpdateMetalsViewModel()
        {
            MetalIndexService service = new();
            PreciousMetalsListingViewModel metalIndexViewModel = new();
            AssetModelingServices assetServices = new(service);

            await assetServices.LoadAssetModelData(service);

            await metalIndexViewModel.LoadAssetsFromBank(metalIndexViewModel);
        }

        private async Task LoadAssetsFromBank(PreciousMetalsListingViewModel metalIndexViewModel)
        {
            Gold = AssetBank.Assets[0];
            Silver = AssetBank.Assets[1];
            Platinum = AssetBank.Assets[2];
            Palladium = AssetBank.Assets[3];
        }

        //public static PreciousMetalsListingViewModel LoadMetalsViewModel()
        //{
        //    MetalIndexService service = new();
        //    PreciousMetalsListingViewModel metalIndexViewModel = new();
        //    AssetModelingServices assetServices = new(service);

        //    assetServices.LoadAssetModelData(service);

        //    metalIndexViewModel.LoadAssetsFromBank();

        //    return metalIndexViewModel;
        //}



        // NOTE - below better version that require a parameter (problem in UpdateCurrentCommand) and a ctor with parameter

        //public PreciousMetalsListingViewModel(IMetalIndexServices metalIndexServices)
        //{
        //    _metalIndexServices = metalIndexServices;
        //}

        //public static PreciousMetalsListingViewModel LoadMetalsViewModel(IMetalIndexServices metalIndexServices)
        //{
        //    AssetModelingServices.LoadAssetModelData(metalIndexServices);

        //    PreciousMetalsListingViewModel metalIndexViewModel = new(metalIndexServices);

        //    metalIndexViewModel.LoadAssetsFromBank();

        //    return metalIndexViewModel;
        //}

        //private void LoadAssetsFromBank()
        //{           
        //    Gold = AssetBank.Assets[0];
        //    Silver = AssetBank.Assets[1];
        //    Platinum = AssetBank.Assets[2];
        //    Palladium = AssetBank.Assets[3];
        //}
    }
}
