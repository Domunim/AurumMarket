using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumMarket.WPF.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public MetalIndexViewModel MetalIndexViewModel { get; set; }

        public HomeViewModel(MetalIndexViewModel metalIndexViewModel)
        {
            MetalIndexViewModel = metalIndexViewModel;
        }

    }
}
