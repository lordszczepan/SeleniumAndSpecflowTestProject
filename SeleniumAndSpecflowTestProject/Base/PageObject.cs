using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumAndSpecflowTestProject.Base
{
    public abstract class PageObject
    {
        protected readonly IWebDriver webDriver;

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


    }
}
