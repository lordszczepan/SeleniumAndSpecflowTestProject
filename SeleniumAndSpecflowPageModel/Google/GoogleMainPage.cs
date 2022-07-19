using OpenQA.Selenium;
using SeleniumAndSpecflowPageModel.Base;
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
        }

        public GoogleSidebar Sidebar { get; }

        private Element txtSearch => driver.FindElement(By.XPath("//input[@class='gLFyf gsfi']"));

        private Element btnSearch => driver.FindElement(By.XPath("//div[@class='FPdoLc lJ9FBc']//input[@class='gNO89b']"));

        public override bool IsLoaded()
        {
            return IsElementDisplayed(txtSearch);
        }

        public GoogleSearchResultsPage SearchForPhrase(string searchPhrase)
        {
            txtSearch.TypeText(searchPhrase);

            btnSearch.Click();
            WaitForAjax();

            return new GoogleSearchResultsPage(webDriver);
        }
    }
}
