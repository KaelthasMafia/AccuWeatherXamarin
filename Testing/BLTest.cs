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
        [TestCase("+")]
        [TestCase("~")]
        public void CheckForIncorrectSymbolsInRegularExpression(string str)
        {
            Assert.AreEqual(false, BL.StringIsValid(str));
        }

        [Test]
        [TestCase("qwertyuiopasd fghjklzxcvbnm-")]
        [TestCase("Los-Angeles")]
        [TestCase("Rio De Janeiro")]
        public void CheckForCorrectSymbolsInRegularExpression(string str)
        {
            Assert.AreEqual(true, BL.StringIsValid(str));
        }
    }
}
