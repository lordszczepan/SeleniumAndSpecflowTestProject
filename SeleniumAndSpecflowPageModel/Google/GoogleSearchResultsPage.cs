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

        public override bool IsLoaded()
        {
            return IsElementDisplayed(pnlSearchResults);
        }
    }
}
