﻿using System;
using System.Windows.Automation;
using AccuWeatherXamarin;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UI.AutomationTests.UnitTests.Core;


namespace Testing
{
    [TestClass]
    public class UITest
    {
        [TestMethod]
        public void CheckExistingCityTest()
        {
            //AutomationElement rootElement = AutomationElement.RootElement;
            //Assert.IsNotNull(rootElement);
            Assert.AreEqual(MainPage.CheckExistingCity("Kharkiv"), false);
            //AutomationElement appElement = rootElement.GetControlElement()
        }
    }
}