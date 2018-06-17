using System;
using System.Threading.Tasks;
using AccuWeatherXamarin;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Testing
{
    [TestClass]
    public class DataServiceTest
    {   
        [TestMethod]
        public async Task GetDataFromServiceTest()
        {
            dynamic result;
            result = await DataService.GetDataFromService("http://dataservice.accuweather.com/currentconditions/v1/323903?apikey=MZVGtvqFM9AImHjU0YGwl5mpURNmVBsV");
            Assert.IsNotNull(result);
        }
    }
}
