using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumMarket.Domain.Models
{
    
    public enum AssetType
    {
        Gold,
        Silver,
        Platinum,
        Palladium
    }

    public class AssetModel : DomainObjectModel
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public double PricePerKilogram { get; set; }
        public double Change { get; set; }
        public AssetType Type { get; set; }


        public readonly Dictionary<AssetType, string> assetSymbols = new()
        {
        {AssetType.Gold, "XAU"},
        {AssetType.Silver, "XAG"},
        {AssetType.Platinum, "XPT"},
        {AssetType.Palladium, "XPD"},
        };

    };

}
