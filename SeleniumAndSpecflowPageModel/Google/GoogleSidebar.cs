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

        public override bool IsLoaded()
        {
            return IsElementDisplayed(sidebar);
        }
    }
}
