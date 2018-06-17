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
        [TestMethod]
        public async Task GetCityKeyTest()
        {
            string result;
            result = await API.GetCityKey("Kharkiv");
            Assert.AreEqual(result, "323903");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public async Task GetCityKeyInvalidCityNameTest()
        {
            await API.GetCityKey("InvalidData");
        }

        [TestMethod]
        public async Task GetWeatherForCityTest()
        {
            var weather = await API.GetWeatherForCity("323903");
            Assert.IsNotNull(weather);
            Assert.IsNotNull(weather.IsDayTime);
            Assert.IsNotNull(weather.Temperature);
            Assert.IsNotNull(weather.WeatherText);
        }

        [TestMethod]
        [ExpectedException(typeof(RuntimeBinderException))]
        public async Task GetWeatherForCityInvalidKeyTest()
        {
            var weather = await API.GetWeatherForCity("InvalidData");
        }
    }
}
