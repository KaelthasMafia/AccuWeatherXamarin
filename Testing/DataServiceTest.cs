using System;
using System.Threading.Tasks;
using AccuWeatherXamarin;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Assert = NUnit.Framework.Assert;

namespace Testing
{
    [TestClass]
    public class DataServiceTest
    {
        private DataService dataService = new DataService();

        [TestMethod]
        public async Task GetDataFromServiceTest()
        {
            dynamic result;
            result = await dataService.GetDataFromService("http://dataservice.accuweather.com/currentconditions/v1/323903?apikey=MZVGtvqFM9AImHjU0YGwl5mpURNmVBsV");
            Assert.IsNotNull(result);
        }
    }
}
