using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AccuWeatherXamarin.Models;
using Newtonsoft.Json.Linq;

namespace AccuWeatherXamarin
{
    public static class API
    {
        static string key = "l1CyGVXxsZKVMISp6Ai3DUG8Ajh8Beex";
        public static async Task<string> GetCityKey(string cityName)
        {
            string query = "http://dataservice.accuweather.com/locations/v1/cities/search?apikey=" + key + "&q=" + "cityName";
            dynamic results = await DataService.GetDataFromService(query).ConfigureAwait(false);
            //if (results[0] != null)
            //{
                string cityKey = (string) results[0]["Key"];
                return cityKey;
            //}
            //else
            //{
            //    return null;
            //}


        }

        public static async Task<Weather> GetWeatherForCity(string cityKey)
        {
            string query = "http://dataservice.accuweather.com/currentconditions/v1/" + cityKey + "?apikey=" + key;
            JArray results = await DataService.GetDataFromService(query).ConfigureAwait(false);
            Weather weather = new Weather
            {
                WeatherText = (string)results[0]["WeatherText"],
                IsDayTime = (string)results[0]["IsDayTime"] == "True" ? "Day" : "Night",
                Temperature = (string)results["Temperature"]["Metric"]["Value"] + " C"
            };

            return weather;
        }
    }
}
