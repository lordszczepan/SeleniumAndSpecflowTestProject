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

        private const string btnCountryWikipedia = "//*/div[@lang='{0}']/a";

        private IWebElement txtLogo => webDriver.FindElement(By.ClassName("central-textlogo-wrapper")).
            FindElement(By.XPath("//span[contains(@class,'central-textlogo__image')]"));

        public override bool IsLoaded()
        {
            return IsElementDisplayed(txtLogo);
        }

        public WikipediaMainPage GoToPolishWikipedia()
        {
            GetIWebElementByXPath(btnCountryWikipedia, "pl").Click();
            WaitForAjax();

            return new WikipediaMainPage(webDriver);
        }
    }
}
