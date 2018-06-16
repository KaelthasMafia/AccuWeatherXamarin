using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AccuWeatherXamarin.Models;

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

        static async Task<Weather> GetWeatherForCity(string cityKey)
        {
            string query = "http://dataservice.accuweather.com/currentconditions/v1/" + cityKey + "?apikey=" + key;
            dynamic results = await DataService.GetDataFromService(query).ConfigureAwait(false);
            Weather weather = new Weather();
            try
            {
                weather.WeatherText = (string) results[0]["WeatherText"];
                weather.IsDayTime = (string) results[0]["IsDayTime"] == "True" ? "Day" : "Night";
                weather.Temperature = (string) results["Temperature"]["Metric"]["Value"] + " C";
            }
            catch (Exception)
            {
                // ignored
            }

            return weather;
        }
    }
}
