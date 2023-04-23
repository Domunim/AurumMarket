using System;
using System.Collections.Generic;
using AurumMarket.Domain.Services;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AurumMarket.Domain.Models;
using Newtonsoft.Json;

namespace AurumMarket.MetalPriceAPI.Services
{
    public class MetalIndexService : IMetalIndexServices
    {
        public async Task<MetalIndex> GetMetalIndex(MetalIndexType metalType)
        {
            using(HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://api.metalpriceapi.com/v1/latest?api_key=a4117101fa426aed7f213da73ceb8099&base=USD&currencies=EUR,XAU,XAG");
                string jsonResponse = await response.Content.ReadAsStringAsync();

                MetalIndex metalIndex = JsonConvert.DeserializeObject<MetalIndex>(jsonResponse);
                return metalIndex;
            }
        }
    }
}
