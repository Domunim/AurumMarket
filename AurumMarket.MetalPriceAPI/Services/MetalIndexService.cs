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
        public async Task<ResponseModel> GetMetalIndexResponse()
        {
            using(HttpClient client = new HttpClient())
            {

                // NOTE - final version with editable dates, below test from local file
                //string uri = "https://api.metalpriceapi.com/v1/timeframe?api_key=a4117101fa426aed7f213da73ceb8099" + GetSelectedDate(startDate, endDate);
                string uri = "C:\\Users\\User\\Desktop\\testAllCurrTwoDates.json";

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
            metalIndex.Change = CalculateRateChanges(metalIndex.StartRates, metalIndex.EndRates);

            return metalIndex;
        }

        private string GetSelectedDate(DateOnly startDate, DateOnly endDate)
        {
            return $"&start_date={ startDate.ToString("yyyy-MM-dd") }&end_date={ endDate.ToString("yyyy-MM-dd") }"; 
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
            Dictionary<string, double> rateChangesDict = startRates.ToDictionary(orig => orig.Key, orig => ((endRates[orig.Key] - orig.Value) / orig.Value * 100));
             
            return rateChangesDict;
        }
    }
}
