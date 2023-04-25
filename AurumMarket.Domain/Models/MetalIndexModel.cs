using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumMarket.Domain.Models
{
    public class MetalIndexModel
    {
        public string Base { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public Dictionary<string, double> StartRates { get; set; }
        public Dictionary<string, double> EndRates { get; set; }
        public Dictionary<string, double> Change { get; set; }

    }
}
