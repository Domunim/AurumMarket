using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AurumMarket.WPF.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public PreciousMetalsListingViewModel PreciousMetalsListingViewModel { get; set; }

        public HomeViewModel(PreciousMetalsListingViewModel metalsViewModel)
        {
            PreciousMetalsListingViewModel = metalsViewModel;
        }
    }
}
