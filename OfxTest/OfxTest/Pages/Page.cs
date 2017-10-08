using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace OfxTest.Pages
{
    public abstract class Page : LoadableComponent<Page>
    {
        private readonly IWebDriver _driver;
        private readonly string _url;

        protected Page(IWebDriver driver, string url)
        {
            _driver = driver;
            _url = url;
            PageFactory.InitElements(driver,this);
        }

        public IWebDriver Driver
        {
            get { return _driver; }
        }

        public void MaxPageWindows()
        {
            _driver.Manage().Window.Maximize();
        }
       
    }
}
