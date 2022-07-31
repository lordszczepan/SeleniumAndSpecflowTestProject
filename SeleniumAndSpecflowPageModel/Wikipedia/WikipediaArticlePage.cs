using OpenQA.Selenium;
using SeleniumAndSpecflowPageModel.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumAndSpecflowPageModel.Wikipedia
{
    public class WikipediaArticlePage : PageObject
    {
        public WikipediaArticlePage(IWebDriver webDriver) : base(webDriver)
        {
        }

        private Element mainPage => driver.FindElement(By.XPath("//*[@class='mw-body ve-init-mw-desktopArticleTarget-targetContainer']"));

        private Element txtHeader => driver.FindElement(By.Id("firstHeading"));

        public override bool IsLoaded()
        {
            return IsElementDisplayed(mainPage);
        }

        public string ReturnArticleHeader()
        {
            return txtHeader.GetTextAttribute();
        }
    }
}
