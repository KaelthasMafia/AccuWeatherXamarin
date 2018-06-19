using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.iOS;

namespace UITests
{
    [TestClass]
    public class BasicScenarios
    {
        protected const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        protected static RemoteWebDriver AppSession;
        protected static RemoteWebElement NotificationElement;
        protected static RemoteWebElement SearchByCityElement;
        protected static RemoteWebElement ChooseCityElement;
        protected static RemoteWebElement WeatherTextFirstElement;
        protected static RemoteWebElement WeatherTextSecondElement;
        protected static RemoteWebElement WeatherTextThirdElement;
        protected static RemoteWebElement AddNewCityElement;
        protected static RemoteWebElement AddNewCityTextElement;
        protected static RemoteWebElement DeleteCityElement;
        
        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            //Launch the app
            DesiredCapabilities appCapabilities = new DesiredCapabilities();
            appCapabilities.SetCapability("app", "3b9d9494-f83b-449b-a02c-0756116b7ce_3n2mstymjasv4!App");
            AppSession = new RemoteWebDriver(new Uri(WindowsApplicationDriverUrl), appCapabilities);
            Assert.IsNotNull(AppSession);
            AppSession.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            //locate elements
            SearchByCityElement = AppSession.FindElementByName("Search weather by choosen city") as RemoteWebElement;
            Assert.IsNotNull(SearchByCityElement);
            NotificationElement = AppSession.FindElementsByClassName("TextBox")[0] as RemoteWebElement;
            Assert.IsNotNull(NotificationElement);
            ChooseCityElement = AppSession.FindElementByClassName("ComboBox") as RemoteWebElement;
            Assert.IsNotNull(ChooseCityElement);
            WeatherTextFirstElement = AppSession.FindElementsByClassName("TextBox")[1] as RemoteWebElement;
            Assert.IsNotNull(ChooseCityElement);
            WeatherTextSecondElement = AppSession.FindElementsByClassName("TextBox")[2] as RemoteWebElement;
            Assert.IsNotNull(ChooseCityElement);
            WeatherTextThirdElement = AppSession.FindElementsByClassName("TextBox")[3] as RemoteWebElement;
            Assert.IsNotNull(ChooseCityElement);
            AddNewCityElement = AppSession.FindElementByName("Add new city") as RemoteWebElement;
            Assert.IsNotNull(ChooseCityElement);
            AddNewCityTextElement = AppSession.FindElementsByClassName("TextBox")[4] as RemoteWebElement;
            Assert.IsNotNull(ChooseCityElement);
            DeleteCityElement = AppSession.FindElementByName("Delete choosen city") as RemoteWebElement;
            Assert.IsNotNull(DeleteCityElement);
        }

        [ClassCleanup]
        public static void TearDown()
        {
            NotificationElement = null;
            AppSession.Dispose();
            AppSession = null;
        }

        [TestMethod]
        public void AddAndDeleteNewCityCorrectly()
        {
            DeleteCityElement.Click();
            Thread.Sleep(3000);
            Assert.AreEqual(NotificationElement.Text, "Successfully deleted!");

            AddNewCityTextElement.Clear();
            AddNewCityTextElement.SendKeys("Kharkiv");
            AddNewCityElement.Click();
            Thread.Sleep(3000);
            Assert.AreEqual(NotificationElement.Text, "Successfully saved!");
        }

        [TestMethod]
        public void SearchWeatherByCityTestCase()
        {
            SearchByCityElement.Click();
            Thread.Sleep(3000);
            CheckWeatherFields();
        }

        [TestMethod]
        public void AddExistingCity()
        {
            AddNewCityTextElement.Clear();
            AddNewCityTextElement.SendKeys("1");
            AddNewCityElement.Click();
            //ChooseCityElement.SendKeys("2");
            Thread.Sleep(3000);
            Assert.AreEqual(NotificationElement.Text, "This city already exist");
        }

        [TestMethod]
        public void AddIncorrectCityName()
        {
            AddNewCityTextElement.Clear();
            AddNewCityTextElement.SendKeys("BlaBlaBlaBla");
            AddNewCityElement.Click();
            Thread.Sleep(3000);
            Assert.AreEqual(NotificationElement.Text, "Invalid city name!");
        }

        public void CheckWeatherFields()
        {
            Assert.AreNotEqual(WeatherTextFirstElement.Text, "");
            Assert.AreNotEqual(WeatherTextSecondElement.Text, "");
            Assert.AreNotEqual(WeatherTextThirdElement.Text, "");
        }
    }
}
