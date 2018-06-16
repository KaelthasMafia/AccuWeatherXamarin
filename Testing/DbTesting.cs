using System;
using AccuWeatherXamarin;
using AccuWeatherXamarin.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing
{
    [TestClass]
    public class DbTesting
    {
        [TestMethod]
        public void GetCityListTest()
        {
            CityRepository.GetCityList();
        }

        [TestMethod]
        public void AddCityToDb()
        {
            CityRepository.AddCityToDb(new City {Code = "323903", Name = "Kharkiv"});
        }
    }
}
