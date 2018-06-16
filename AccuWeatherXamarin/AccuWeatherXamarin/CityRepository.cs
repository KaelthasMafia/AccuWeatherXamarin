using System;
using System.Collections.Generic;
using System.Text;
using AccuWeatherXamarin.Models;
using Xamarin.Forms;

namespace AccuWeatherXamarin
{
    public static class CityRepository
    {
        private static List<string> cities;
        static CityRepository()
        {
            cities = new List<string>();
        }

        public static void AddCityToDb(City city)
        {
            Application.Current.Properties.Add(city.Code, city.Name);
            //await Application.Current.SavePropertiesAsync();
        }

        public static List<string> GetCityList()
        {
            foreach (var currentProperty in Application.Current.Properties)
            {
                cities.Add(currentProperty.Value as string);
            }
            return cities;
        }
    }
}
