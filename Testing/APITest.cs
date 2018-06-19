using System;
using System.Threading.Tasks;
using AccuWeatherXamarin;
using AccuWeatherXamarin.Models;
using Microsoft.CSharp.RuntimeBinder;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing
{
    [TestClass]
    public class APITest
    {
        private API api;

        public APITest()
        {
            api = new API("e9zfjBFMiEWx2iWzVKliGZhfRcAIVRSR");
        }
        

        [TestMethod]
        public async Task GetCityKeyTest()
        {
            string result;
            result = await api.GetCityKey("Kharkiv");
            Assert.AreEqual(result, "323903");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public async Task GetCityKeyInvalidCityNameTest()
        {
            await api.GetCityKey("InvalidData");
        }

        [TestMethod]
        public async Task GetWeatherForCityTest()
        {
            var weather = await api.GetWeatherForCity("323903");
            Assert.IsNotNull(weather);
            Assert.IsNotNull(weather.IsDayTime);
            Assert.IsNotNull(weather.Temperature);
            Assert.IsNotNull(weather.WeatherText);
        }

        [TestMethod]
        [ExpectedException(typeof(RuntimeBinderException))]
        public async Task GetWeatherForCityInvalidKeyTest()
        {
            var weather = await api.GetWeatherForCity("InvalidData");
        }
    }
}
