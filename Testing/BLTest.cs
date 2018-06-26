using System;
using AccuWeatherXamarin;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Testing
{
    [TestClass]
    public class BLTest
    {
        [Test]
        [TestCase("1")]
        [TestCase("2")]
        [TestCase("!")]
        [TestCase("@")]
        [TestCase("#")]
        [TestCase("$")]
        [TestCase("%")]
        [TestCase("^")]
        [TestCase("&")]
        [TestCase("*")]
        [TestCase("(")]
        [TestCase(")")]
        [TestCase("_")]
        [TestCase("-")]
        [TestCase("+")]
        [TestCase("~")]
        public void CheckForRegularException(string str)
        {
            Assert.AreEqual(false, BL.StringIsValid(str));
        }
    }
}
