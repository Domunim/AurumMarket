using System;
using System.Collections.Generic;
using AurumMarket.Domain.Services;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AurumMarket.Domain.Models;
using Newtonsoft.Json;
using System.Diagnostics.Metrics;
using System.Text.Json.Serialization;

namespace AurumMarket.MetalPriceAPI.Services
{
    public class MetalIndexService : IMetalIndexServices
    {
        public async Task<MetalIndex> GetMetalIndex()
        {
            using(HttpClient client = new HttpClient())
            {

                // final version with editable dates and currencies
                //string uri = "https://api.metalpriceapi.com/v1/" + GetSelectedDate(startDate, endDate) + "?api_key=a4117101fa426aed7f213da73ceb8099" + GetSelectedCurrencies(currencyCodes);

                // NOTE - test version URI
                string uri = "https://api.metalpriceapi.com/v1/latest?api_key=a4117101fa426aed7f213da73ceb8099";


                HttpResponseMessage response = await client.GetAsync(uri);
                string jsonResponse = await response.Content.ReadAsStringAsync();

                // TODO - if 2 different dates returned, create two models
                //if (startDate != endDate)
                //{
                //    deserialise to 2 models
                //}
                //else

                MetalIndex metalIndex = JsonConvert.DeserializeObject<MetalIndex>(jsonResponse);
                
                return metalIndex;
            }
        }

        private string GetSelectedDate(DateOnly startDate, DateOnly endDate)
        {
            string dateOutput = string.Empty;
            
            if (startDate == DateOnly.FromDateTime(DateTime.Now) && startDate == endDate)
            {
                return "latest";
            }
            else if (startDate == endDate)
            {
                return startDate.ToString("yyyy-MM-dd");
            }
            else
            {
                return $"timeframe?start_date={ startDate.ToString("yyyy-MM-dd") }&end_date={ endDate.ToString("yyyy-MM-dd") }"; 
            }

        }


        private string GetSelectedCurrencies(List<string> currencyCodes)
        {
            string currencyOutput = "&currencies=";

            foreach (string currencyCode in currencyCodes)
            {
                currencyOutput += currencyCode + ",";
            }

            return currencyOutput.Remove(currencyOutput.Length - 1, 1);
        }
    }
}
