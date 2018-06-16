using System;
using AccuWeatherXamarin;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing
{
    [TestClass]
    public class JsonTesting
    {
        [TestMethod]
        public void CityKeyTest()
        {
            Assert.Equals(API.GetCityKey("Kharkiv"), "323903");

        }
    }
}
