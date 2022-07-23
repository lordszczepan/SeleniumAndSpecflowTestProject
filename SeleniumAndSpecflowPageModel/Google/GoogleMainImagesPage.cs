using OpenQA.Selenium;
using SeleniumAndSpecflowPageModel.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumAndSpecflowPageModel.Google
{
    public class GoogleMainImagesPage : PageObject
    {
        public GoogleMainImagesPage(IWebDriver webDriver) : base(webDriver)
        {
            Sidebar = new GoogleSidebar(webDriver);
        }

        public GoogleSidebar Sidebar { get; }

        private Element imgLogo => driver.FindElement(By.XPath("//div[@class='k1zIA rSk4se']/img[@class='lnXdpd']"));

        private Element txtSearch => driver.FindElement(By.XPath("//input[@class='gLFyf gsfi']"));

        public override bool IsLoaded()
        {
            return IsElementDisplayed(imgLogo);
        }
    }
}
