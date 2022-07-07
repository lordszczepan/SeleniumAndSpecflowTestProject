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
        protected readonly Driver driver;
        private const int defaultWaitTime = 60;

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

        protected void WaitForAjax(int seconds = defaultWaitTime)
        {
            var js = (IJavaScriptExecutor)webDriver;
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds));
            wait.Until(wd => js.ExecuteScript("return jQuery.active").ToString() == "0");
        }

        protected void WaitUntilPageLoadsCompletely(int seconds = defaultWaitTime)
        {
            var js = (IJavaScriptExecutor)webDriver;
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds));
            wait.Until(wd => js.ExecuteScript("return document.readyState").ToString() == "complete");
        }

        protected void WaitForElementToBeVisible(By search, int seconds = defaultWaitTime)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.ElementIsVisible(search));
        }

        protected void WaitForElementToBeInvisible(By search, int seconds = defaultWaitTime)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(search));
        }

        protected void WaitForElementToBeClickable(By search, int seconds = defaultWaitTime)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(search));
        }

        protected void ScrollToPosition(int xPosition = 0, int yPosition = 0)
        {
            Console.WriteLine($"Scroll To Position: X:'{xPosition}' Y:'{yPosition}'");
            IJavaScriptExecutor js = (IJavaScriptExecutor)webDriver;
            js.ExecuteScript(($"window.scrollTo({xPosition}, {yPosition})"));
        }
    }
}
