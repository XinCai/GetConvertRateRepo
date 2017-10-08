using System;
using System.Configuration;
using OfxTest.Modules;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace OfxTest.Pages
{
    public class OfxLandingPage : Page
    {
        public const string Path = "en-au/";
        private readonly WebDriverWait _wait;
        private readonly Actions action;

        [FindsBy(How = How.Id, Using = "currency-converter--input--you")]
        private readonly IWebElement _inputCurrencyConvertYou;

        [FindsBy(How = How.ClassName, Using = "currency-converter--toolbar--loader")]
        private readonly IWebElement _divConverterLoader;

        public OfxLandingPage(IWebDriver driver, string url) : base(driver, url)
        {
            _wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            action = new Actions(driver);
        }

        protected override void ExecuteLoad()
        {
            Driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["Server.Base"] + Path);
        }

        protected override bool EvaluateLoadedStatus()
        {
            return Driver.Url.Contains(Path);
        }

        /// <summary>
        ///     wait for spinner
        /// </summary>
        public void WaitForConvert()
        {
            _wait.Until(driver => driver.FindElement(By.ClassName("currency-converter--toolbar--loader"))
                .GetAttribute("style").Contains("opacity: 0;"));
        }

        /// <summary>
        ///     select currency
        /// </summary>
        /// <param name="currency"></param>
        public void SelectCurrencyConvertFrom(Currency currency)
        {
            action.MoveToElement(Driver.FindElement(By.Id("select2-currency-converter--you-container"))).Click()
                .Perform();
            var element = Driver.FindElements(By.CssSelector("#select2-currency-converter--you-results>li>ul>li"));

            switch (currency)
            {
                case Currency.AUD:
                    element[0].Click();
                    break;
                case Currency.EUR:
                    element[1].Click();
                    break;
                case Currency.GBP:
                    element[2].Click();
                    break;
                case Currency.JPY:
                    element[3].Click();
                    break;
                case Currency.USD:
                    element[4].Click();
                    break;
            }
        }

        /// <summary>
        /// Result Container
        /// </summary>
        /// <param name="currency"></param>
        public void SelectCurrencyConvertTo(Currency currency)
        {
            action.MoveToElement(Driver.FindElement(By.Id("select2-currency-converter--recipient-container"))).Click()
                .Perform();
            var element =
                Driver.FindElements(By.CssSelector("#select2-currency-converter--recipient-results>li>ul>li"));

            switch (currency)
            {
                case Currency.AUD:
                    element[0].Click();
                    break;
                case Currency.JPY:
                    element[3].Click();
                    break;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="value">convert currency</param>
        public void InputCurrency(string value)
        {
            _inputCurrencyConvertYou.Clear();
            _inputCurrencyConvertYou.SendKeys(value);
        }

        public string GetCustomerRate()
        {
            WaitForConvert();
            var resultInput = Driver.FindElement(By.ClassName("currency-converter--customer-rate"));
            return resultInput.Text;
        }
    }
}