using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumAndSpecflowPageModel.Base
{
    public class WebElement : Element
    {
        private readonly IWebDriver webDriver;
        private readonly IWebElement webElement;
        private readonly By by;
        private const int defaultWaitTime = 60;

        public WebElement(IWebDriver webDriver, IWebElement webElement, By by)
        {
            this.webDriver = webDriver;
            this.webElement = webElement;
            this.by = by;
        }

        public override By By => by;

        public override string Text => webElement?.Text;

        public override bool? Enabled => webElement?.Enabled;

        public override bool? Displayed => webElement?.Displayed;

        public override void Click()
        {
            WaitToBeClickable(By);
            webElement?.Click();
        }

        public override void ScrollTo()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)webDriver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", webElement.FindElement(By));
        }

        public override Element FindElement(By locator)
        {
            return new WebElement(webDriver, webElement?.FindElement(locator), locator);
        }

        public override string GetAttribute(string attributeName)
        {
            return webElement?.GetAttribute(attributeName);
        }

        public override void TypeText(string text)
        {
            Thread.Sleep(500);
            webElement?.Clear();
            webElement?.SendKeys(text);
        }

        private void WaitToBeClickable(By by, int seconds = defaultWaitTime)
        {
            var webDriverWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds));
            webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
        }

        protected void WaitForAjax(int seconds = defaultWaitTime)
        {
            var js = (IJavaScriptExecutor)webDriver;
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds));
            wait.Until(wd => js.ExecuteScript("return jQuery.active").ToString() == "0");
        }
    }
}
