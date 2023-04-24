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
    public class MetalIndexViewModel
    {
        private readonly IMetalIndexServices _metalIndexServices;
        public MetalIndex requestedIndex { get; set; }

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
            await _metalIndexServices.GetMetalIndex();
        }
    }
}
