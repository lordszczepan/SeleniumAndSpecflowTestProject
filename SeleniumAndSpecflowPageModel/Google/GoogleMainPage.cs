using OpenQA.Selenium;
using SeleniumAndSpecflowPageModel.Base;
using SeleniumAndSpecflowPageModel.Google.Modals;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumAndSpecflowPageModel.Google
{
    public class GoogleMainPage : PageObject
    {
        public GoogleMainPage(IWebDriver webDriver) : base(webDriver)
        {
            Sidebar = new GoogleSidebar(webDriver);

            var cookiesPopup = new GoogleCookiesModal(webDriver);
            if (cookiesPopup.IsLoaded())
            {
                cookiesPopup.AcceptAllCookies();
            }
        }
        
        public GoogleSidebar Sidebar { get; }

        private Element imgLogo => driver.FindElement(By.XPath("//div[@class='k1zIA rSk4se']/img[@class='lnXdpd']"));

        private Element txtSearch => driver.FindElement(By.XPath("//input[@class='gLFyf gsfi']"));

        private Element btnSearch => driver.FindElement(By.XPath("//div[@class='FPdoLc lJ9FBc']//input[@class='gNO89b']"));

        private Element btnSearchDropDownArea => driver.FindElement(By.XPath("//div[@class='aajZCb']//input[@class='gNO89b']"));

        public override bool IsLoaded()
        {
            return IsElementDisplayed(imgLogo);
        }

        public GoogleSearchResultsPage SearchForPhrase(string searchPhrase)
        {
            txtSearch.TypeText(searchPhrase);
            
            btnSearchDropDownArea.Click();
            WaitUntilPageLoadsCompletely();

            return new GoogleSearchResultsPage(webDriver);
        }
    }
}
