using System;
using NUnit.Framework;
using OfxTest.Modules;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace OfxTest.Tests
{
    public class TestBase
    {
        public IWebDriver Driver { get; private set; }

        protected virtual void AdditionalSetup()
        {
            // add additional setup here
        }

        [SetUp]
        public void Setup()
        {
            Driver = DriverFactory.GetDriver();
            AdditionalSetup();
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Status == TestStatus.Failed)
            {
                var screenshot = Driver.TakeScreenshot();
                screenshot.SaveAsFile(DateTime.Now.ToString("yyyyMMMMdd")+TestContext.CurrentContext.Test.FullName+".png",ScreenshotImageFormat.Png);
            }
            Driver.Quit();
        }
    }
}
