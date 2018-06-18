using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.iOS;

namespace CalculatorTest
{
    [TestClass]
    public class BasicScenarios
    {
        protected const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        protected static RemoteWebDriver AppSession;
        protected static RemoteWebElement NotificationElement;
        protected static RemoteWebElement SearchByCityElement;
        protected static RemoteWebElement ChooseCityElement;
        protected static RemoteWebElement ComboBoxItemFirst;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            //Launch the app
            DesiredCapabilities appCapabilities = new DesiredCapabilities();

            //appCapabilities.SetCapability("app", "57b3a460-8843-4d84-822a-9f316274c2bf_tz6ph9wdjhqw8!App");
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
        }

        [ClassCleanup]
        public static void TearDown()
        {
            NotificationElement = null;
            AppSession.Dispose();
            AppSession = null;
        }

        [TestMethod]
        public void SearchByCityTestCase()
        {
            string s = "Please, choose city from picker!";
            SearchByCityElement.Click();
            Assert.AreEqual(s, NotificationElement.Text);

            ChooseCityElement.Click();
            ComboBoxItemFirst = AppSession.FindElementsByClassName("ComboBoxItem")[0] as RemoteWebElement;
            Assert.IsNotNull(ComboBoxItemFirst);
            ComboBoxItemFirst.Click();
            System.Threading.Thread.Sleep(5000);
            Assert.AreEqual("", NotificationElement.Text);
        }
    }
}
