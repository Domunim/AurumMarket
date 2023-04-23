using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumMarket.Domain.Models
{

    public enum MetalIndexType
    {
        XAG,
        XAU
    }

    public class MetalIndex
    {
        public string Base { get; set; }
        public string Name { get; set; }
        public double RateEUR { get; set; }

    }
}
