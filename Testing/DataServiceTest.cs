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
        //[TestCase("http://dataservice.accuweather.com/currentconditions/v1/323903?apikey=X7Nmkx6DNEHVjVXa4KBp1gNrLTJTJn1y")]
        public async Task GetDataFromServiceTest()
        {
            dynamic result;
            result = await DataService.GetDataFromService("http://dataservice.accuweather.com/currentconditions/v1/323903?apikey=X7Nmkx6DNEHVjVXa4KBp1gNrLTJTJn1y");
            Assert.IsNotNull(result);
        }
    }
}
