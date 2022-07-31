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

        public override bool IsLoaded()
        {
            return IsElementDisplayed(mainPage);
        }
    }
}
