using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SeleniumAndSpecflowPageModel.Base
{
    public class Driver
    {
        protected readonly IWebDriver webDriver;

        public Driver(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        //public abstract void Start(Browser browser);
        //public abstract void Quit();
        //public abstract void GoToUrl(string url);
        //public abstract Element FindElement(By locator);
        //public abstract List<Element> FindElements(By locator);

        public Element FindElement(By locator)
        {
            WebDriverWait webDriverWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(30));
            IWebElement nativeWebElement =
                webDriverWait.Until(ExpectedConditions.ElementExists(locator));
            Element element = new WebElement(webDriver, nativeWebElement, locator);

            Element logElement = new LogElement(element);

            return logElement;
        }

        public List<Element> FindElements(By locator)
        {
            WebDriverWait webDriverWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(30));
            ReadOnlyCollection<IWebElement> nativeWebElements =
                webDriverWait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(locator));
            var elements = new List<Element>();
            foreach (var nativeWebElement in nativeWebElements)
            {
                Element element = new WebElement(webDriver, nativeWebElement, locator);
                elements.Add(element);
            }

            return elements;
        }
    }
}
