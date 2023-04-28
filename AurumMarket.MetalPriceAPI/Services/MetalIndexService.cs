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
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace AurumMarket.MetalPriceAPI.Services
{
    public class MetalIndexService : IMetalIndexServices
    {
        public async Task<ResponseModel> GetResponseFromAPI()
        {
            using(HttpClient client = new HttpClient())
            {

                // NOTE - test API call, example dates matching downloaded JSON
                // string uri = "https://api.metalpriceapi.com/v1/timeframe?api_key=a4117101fa426aed7f213da73ceb8099&start_date=2021-04-22&end_date=2021-04-23";

                // NOTE - final call, with today and yesterday
                string uri = $"https://api.metalpriceapi.com/v1/timeframe?api_key=a4117101fa426aed7f213da73ceb8099&start_date={DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd")}&end_date={DateTime.Today.ToString("yyyy-MM-dd")}";


                HttpResponseMessage response = await client.GetAsync(uri);
                string jsonResponse = await response.Content.ReadAsStringAsync();

                ResponseModel modelFromAPI = JsonConvert.DeserializeObject<ResponseModel>(jsonResponse);

                return modelFromAPI;
               
            }
        }

        public MetalIndexModel ConvertToMetalIndex(ResponseModel modelfromAPI)
        {

            MetalIndexModel metalIndex = new();

            metalIndex.Base = modelfromAPI.Base;
            metalIndex.StartDate = DateOnly.Parse(modelfromAPI.StartDate);
            metalIndex.EndDate = DateOnly.Parse(modelfromAPI.EndDate);
            metalIndex.StartRates = ChangeToStringDoubleDictionary(ObjectToDictionary(modelfromAPI.Rates.StartDateRates));
            metalIndex.EndRates = ChangeToStringDoubleDictionary(ObjectToDictionary(modelfromAPI.Rates.EndDateRates));
            metalIndex.Changes = CalculateRateChanges(metalIndex.StartRates, metalIndex.EndRates);

            return metalIndex;
        }
         
        public AssetModel MakeAssetFromIndex(MetalIndexModel metalIndex, AssetType type)
        {
            AssetModel assetModel = new();

            assetModel.Type = type;
            assetModel.Name = type.ToString();
            assetModel.Symbol = assetModel.assetSymbols[type];
            assetModel.PricePerKilogram = 1 / metalIndex.EndRates[assetModel.Symbol] * 32.150746568628;
            assetModel.Change = metalIndex.Changes[assetModel.Symbol];

            return assetModel;
        }

        public static Dictionary<string, object> ObjectToDictionary(object obj)
        {
            Dictionary<string, object> returnedDict = new();

            foreach (PropertyInfo prop in obj.GetType().GetProperties())
            {
                string propName = prop.Name;
                
                var value = obj.GetType().GetProperty(propName).GetValue(obj, null);
                
                if (value != null)
                {
                    returnedDict.Add(propName, value);
                }
                else
                {
                    returnedDict.Add(propName, null);
                }
            }

            return returnedDict;
        }

        public static Dictionary<string, double> ChangeToStringDoubleDictionary(Dictionary<string, object> dictionaryStrObj)
        {
            Dictionary<string, double> finalDict = new();

            foreach (KeyValuePair<string, object> kvp in dictionaryStrObj)
            {
                finalDict.Add(kvp.Key, double.Parse(kvp.Value.ToString()));
            }

            return finalDict;
        }

        public static Dictionary<string, double> CalculateRateChanges(Dictionary<string, double> startRates, Dictionary<string, double> endRates)
        {
            
            // NOTE - version to calculate change in $
            Dictionary<string, double> rateChangesDict = startRates.ToDictionary(orig => orig.Key, orig => (1/ endRates[orig.Key] * 32.150746568628 - 1 / orig.Value * 32.150746568628));

            // NOTE - version to calculate % change
            // Dictionary<string, double> rateChangesDict = startRates.ToDictionary(orig => orig.Key, orig => ((endRates[orig.Key] - orig.Value) / orig.Value * 100));

            return rateChangesDict;
        }
    }
}
