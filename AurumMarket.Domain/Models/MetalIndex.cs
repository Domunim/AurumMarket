using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumMarket.Domain.Models
{
    public class MetalIndex
    {
        public string Base { get; set; } = "USD";
        public DateOnly Date { get; set; } // = DateOnly.FromDateTime(DateTime.Now);
        public Dictionary<string, double> Rates { get; set; }

    }
}
