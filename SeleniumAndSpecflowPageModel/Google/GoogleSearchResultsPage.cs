using OpenQA.Selenium;
using SeleniumAndSpecflowPageModel.Base;
using SeleniumAndSpecflowPageModel.Wikipedia;
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

        public WikipediaArticlePage EnterWikipediaArticleBySearchResult(string searchResult)
        {
            Element wikiArticle = driver.FindElement(By.XPath($"//*[@id='rso']/div/div/div/div/a[div/cite[contains(text(),'wikipedia.org')]][h3[contains(text(),'{searchResult}')]]"));
            wikiArticle.ScrollTo();
            wikiArticle.Click();
            WaitForAjax();

            return new WikipediaArticlePage(webDriver);
        }
    }
}
