using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AccuWeatherXamarin.Models;
using Newtonsoft.Json.Linq;

namespace AccuWeatherXamarin
{
    public class API
    {
        private readonly string key;
        private readonly DataService dataService;
        public API(string key)
        {
            this.key = key;
            dataService = new DataService();
        }

         //"APBox2VjIW5hH9z4CjkeiaCM7NFu33K3";
        public async Task<string> GetCityKey(string cityName)
        {
            string query = "http://dataservice.accuweather.com/locations/v1/cities/search?apikey=" + key + "&q=" + cityName;
            dynamic results = await dataService.GetDataFromService(query).ConfigureAwait(false);
            string cityKey = (string)results[0]["Key"];
            return cityKey;
        }

        public async Task<Weather> GetWeatherForCity(string cityKey)
        {
            string query = "http://dataservice.accuweather.com/currentconditions/v1/" + cityKey + "?apikey=" + key;
            JArray results = await dataService.GetDataFromService(query).ConfigureAwait(false);
            Weather weather = new Weather
            {
                WeatherText = (string)results[0]["WeatherText"],
                IsDayTime = (string)results[0]["IsDayTime"] == "True" ? "Day" : "Night",
                Temperature = (string)results[0]["Temperature"]["Metric"]["Value"] + " C"
            };
            return weather;
        }
    }
}
