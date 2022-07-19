using OpenQA.Selenium;
using SeleniumAndSpecflowPageModel.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumAndSpecflowPageModel.Google
{
    public class GoogleSearchResultsPage : PageObject
    {
        public GoogleSearchResultsPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        private const string pnlSearchResultsClass = "GyAeWb";

        private Element pnlSearchResults => driver.FindElement(By.ClassName(pnlSearchResultsClass));

        private Element txtSearch => driver.FindElement(By.XPath("//*[@id='tsf']/div[1]//input"));

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
