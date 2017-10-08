using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OfxTest.Modules
{
    public class DriverFactory
    {
        /// <summary>
        /// private constructor 
        /// </summary>
        private DriverFactory()
        {            
        }

        /// <summary>
        /// current framework support 3 browsers 
        /// can add more driver option when need 
        /// </summary>
        /// <returns></returns>
        public static IWebDriver GetDriver()
        {
            var driverType = ConfigurationManager.AppSettings["Driver"] ?? Browser.Chrome;

            if (driverType.ToLower().Equals(Browser.FireFox))
            {
                //TODO: Add firefox
            }
            if (driverType.ToLower().Equals(Browser.Chrome))
            {
                var options = new ChromeOptions
                {
                    BinaryLocation = 
                    Environment.GetEnvironmentVariable("CHROME_EXECUTABLE")??
                    ConfigurationManager.AppSettings["ChromeBinaryLocation"] ??
                    @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe"

                };
                return new ChromeDriver(options);
            }
            if (driverType.ToLower().Equals(Browser.InternetExplorer))
            {
               //TODO: Add IE driver
            }
            //TODO: Add Grid , phantomjs

            throw new WebDriverException("The specified browser type is not supported by framework "+ driverType);
        }
    }
}
