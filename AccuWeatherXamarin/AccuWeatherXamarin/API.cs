using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccuWeatherXamarin
{
    public static class API
    {
        static string key = "l1CyGVXxsZKVMISp6Ai3DUG8Ajh8Beex";
        static async Task<dynamic> GetCityKey(string cityName)
        {
            string query = "http://dataservice.accuweather.com/locations/v1/cities/search?apikey=" + key + "&q=" + "cityName";
            dynamic results = await DataService.GetDataFromService(query).ConfigureAwait(false);
            string cityKey = (string)results[0]["Key"];
            return cityKey;
        }

        //static async Task<dynamic> GetWeatherForCity(string cityKey)
        //{
        //    string query = "http://dataservice.accuweather.com/forecasts/v1/daily/1day/" + cityKey + "?apikey=" + key;
        //    dynamic results = await DataService.GetDataFromService(query).ConfigureAwait(false);
        //}
    }
}
