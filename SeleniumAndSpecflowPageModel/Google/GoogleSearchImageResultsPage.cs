using OpenQA.Selenium;
using SeleniumAndSpecflowPageModel.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumAndSpecflowPageModel.Google
{
    public class GoogleSearchImageResultsPage : PageObject
    {
        public GoogleSearchImageResultsPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        private const string pnlSearchResultsID = "gsr";

        private Element pnlSearchResults => driver.FindElement(By.Id(pnlSearchResultsID));

        private Element txtSearch => driver.FindElement(By.XPath("//*[@id='sf']/div[1]//input"));

        public override bool IsLoaded()
        {
            return IsElementDisplayed(pnlSearchResults);
        }

        public string ReturnSearchTextBoxValue()
        {
            return txtSearch.GetAttribute("value");
        }
    }
}
