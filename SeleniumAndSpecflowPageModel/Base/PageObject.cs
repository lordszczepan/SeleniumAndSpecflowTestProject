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

        private const int defaultWaitTime = 60;

        public PageObject(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public abstract bool IsLoaded();

        protected bool IsElementDisplayed(IWebElement webElement)
        {
            try
            {
                return webElement.Displayed;
            }
            catch
            {
                return false;
            }
        }

        protected IWebElement GetIWebElementByXPath(string webElementXPath, params string[] argument)
        {
            string locator = string.Format(webElementXPath, argument);
            IWebElement webElement = webDriver.FindElement(By.XPath(locator));
            return webElement;
        }

        protected void Sleep(double seconds = 1.0) //defaultWaitTime)
        {
            System.Threading.Thread.Sleep((int)(1000 * seconds));
        }

        protected void WaitForAjax(int seconds = defaultWaitTime)
        {
            var js = (IJavaScriptExecutor)webDriver;
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds));
            wait.Until(wd => js.ExecuteScript("return jQuery.active").ToString() == "0");
        }
    }
}
