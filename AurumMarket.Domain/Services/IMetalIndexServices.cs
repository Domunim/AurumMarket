using AurumMarket.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumMarket.Domain.Services
{
    public interface IMetalIndexServices
    {
        Task<ResponseModel> GetResponseFromAPI();

        MetalIndexModel ConvertToMetalIndex(ResponseModel modelfromAPI);

        AssetModel MakeAssetFromIndex(MetalIndexModel metalIndex, AssetType type);
    }
}
