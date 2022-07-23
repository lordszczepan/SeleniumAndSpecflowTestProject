using OpenQA.Selenium;
using SeleniumAndSpecflowPageModel.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumAndSpecflowPageModel.Google
{
    public class GoogleSidebar : PageObject
    {
        public GoogleSidebar(IWebDriver webDriver) : base(webDriver)
        {
        }

        private const string sidebarXPath = "//div[@class='gb_Vd gb_Xa gb_Kd']";

        private Element sidebar => driver.FindElement(By.XPath(sidebarXPath));

        private Element btnImages => driver.FindElement(By.XPath(sidebarXPath)).FindElement(By.XPath("//a[contains(@href,'www.google')][contains(@href,'imghp')]"));

        public override bool IsLoaded()
        {
            return IsElementDisplayed(sidebar);
        }

        public void GoToImages()
        {
            btnImages.Click();
            WaitUntilPageLoadsCompletely();
        }
    }
}
