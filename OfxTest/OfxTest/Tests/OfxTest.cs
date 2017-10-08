using System;
using NUnit.Framework;
using OfxTest.Pages;
using OfxTest.TestData;

namespace OfxTest.Tests
{
    [TestFixture]
    public class OfxTest : TestBase
    {
        private OfxLandingPage _landingPage;
        private CurrencyData _data;

        protected override void AdditionalSetup()
        {
            _landingPage = new OfxLandingPage(Driver, OfxLandingPage.Path);
            _data = Utilies.Get();
        }

        [Test]
        public void CustomerRateTest()
        {
            _landingPage.Load();
            _landingPage.MaxPageWindows();
            _landingPage.SelectCurrencyConvertFrom(_data.InputCurrency);
            _landingPage.InputCurrency(_data.InputAmount);
            _landingPage.SelectCurrencyConvertTo(_data.RecipientCurrency);
            _landingPage.WaitForConvert();
            var expeCustomerRate = _data.CustomerRate;
            var actualCustomerRate = (int) Convert.ToDouble(_landingPage.GetCustomerRate());
            Assert.AreEqual(expeCustomerRate, actualCustomerRate);
        }
    }
}