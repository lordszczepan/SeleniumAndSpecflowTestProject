using OpenQA.Selenium;
using SeleniumAndSpecflowPageModel.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumAndSpecflowPageModel.Google.Modals
{
    public class GoogleCookiesModal : PageObject
    {
        public GoogleCookiesModal(IWebDriver webDriver) : base(webDriver)
        {
        }

        private const string modalWindowID = "CXQnmb";

        private Element modalWindow => driver.FindElement(By.Id(modalWindowID));

        private Element btnAcceptAll => driver.FindElement(By.XPath("//*[@id='L2AGLb']"));

        public override bool IsLoaded()
        {
            return IsElementDisplayed(modalWindow);
        }

        public void AcceptAllCookies()
        {
            btnAcceptAll.Click();
            WaitUntilPageLoadsCompletely();
        }
    }
}
