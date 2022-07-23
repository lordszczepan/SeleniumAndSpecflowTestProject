using OpenQA.Selenium;
using SeleniumAndSpecflowPageModel.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumAndSpecflowPageModel.Wikipedia
{
    public class WikipediaWelcomePage : PageObject
    {
        public WikipediaWelcomePage(IWebDriver webDriver) : base(webDriver)
        {
        }

        private const string btnMainLangWikipedia = "//*/div[@lang='{0}']/a";
        private const string btnAllLangWikipedia = "//*[@id='js-lang-lists']/div//a[text()='{0}']";


        private Element txtLogo => driver.FindElement(By.ClassName("central-textlogo-wrapper")).
            FindElement(By.XPath("//span[contains(@class,'central-textlogo__image')]"));

        private Element btnReadWikiInLang => driver.FindElement(By.Id("js-lang-list-button"));

        public override bool IsLoaded()
        {
            return IsElementDisplayed(txtLogo);
        }

        public WikipediaMainPage GoToPolishWikipediaByMainLanguages()
        {
            GetIWebElementByXPath(btnMainLangWikipedia, "pl").Click();
            WaitForAjax();

            return new WikipediaMainPage(webDriver);
        }

        public WikipediaMainPage GoToPolishWikipediaByAllLanguages()
        {
            btnReadWikiInLang.Click();
            WaitUntilPageLoadsCompletely();

            GetIWebElementByXPath(btnAllLangWikipedia, "Polski").Click();
            WaitForAjax();

            return new WikipediaMainPage(webDriver);
        }
    }
}
