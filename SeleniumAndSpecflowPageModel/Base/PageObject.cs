using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using SeleniumExtras.WaitHelpers;

namespace SeleniumAndSpecflowPageModel.Base
{
    public abstract class PageObject
    {
        protected readonly IWebDriver webDriver;
        //private WebDriverWait webDriverWait;
        private const int defaultWaitTime = 60;
        protected readonly Driver driver;

        public PageObject(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            driver = new Driver(webDriver);
        }

        public abstract bool IsLoaded();

        protected bool IsElementDisplayed(Element webElement)
        {
            try
            {
                return (bool)webElement.Displayed;
            }
            catch
            {
                return false;
            }
        }

        protected Element GetIWebElementByXPath(string webElementXPath, params string[] argument)
        {
            string locator = string.Format(webElementXPath, argument);
            Element webElement = driver.FindElement(By.XPath(locator));
            return webElement;
        }

        protected void Sleep(double seconds = 1.0)
        {
            System.Threading.Thread.Sleep((int)(1000 * seconds));
        }

        //public override Element FindElement(By locator)
        //{
        //    WebDriverWait webDriverWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(defaultWaitTime));
        //    IWebElement nativeWebElement =
        //        webDriverWait.Until(ExpectedConditions.ElementExists(locator));
        //    Element element = new WebElement(webDriver, nativeWebElement, locator);

        //    Element logElement = new LogElement(element);

        //    return logElement;
        //}

        //public override List<Element> FindElements(By locator)
        //{
        //    WebDriverWait webDriverWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(defaultWaitTime));
        //    ReadOnlyCollection<IWebElement> nativeWebElements =
        //        webDriverWait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(locator));
        //    var elements = new List<Element>();
        //    foreach (var nativeWebElement in nativeWebElements)
        //    {
        //        Element element = new WebElement(webDriver, nativeWebElement, locator);
        //        elements.Add(element);
        //    }

        //    return elements;
        //}

        protected void WaitForAjax(int seconds = defaultWaitTime)
        {
            var js = (IJavaScriptExecutor)webDriver;
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds));
            wait.Until(wd => js.ExecuteScript("return jQuery.active").ToString() == "0");
        }
    }
}
