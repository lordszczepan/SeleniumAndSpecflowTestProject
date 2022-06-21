using OpenQA.Selenium;
using SeleniumAndSpecflowTestProject.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumAndSpecflowPageModel.Wikipedia
{
    public class WikiWelcomePage : PageObject
    {
        public WikiWelcomePage(IWebDriver webDriver) : base(webDriver)
        {
        }

        private const string btnCountryWikipedia = "//*/div[@lang='{0}']/a";

        private IWebElement txtLogo => webDriver.FindElement(By.ClassName("central-textlogo-wrapper")).
            FindElement(By.XPath("//span[contains(@class,'central-textlogo__image')]"));

        public override bool IsLoaded()
        {
            return IsElementDisplayed(txtLogo);
        }

        public WikiMainPage GoToPolishWikipedia()
        {
            GetIWebElementByXPath(btnCountryWikipedia, "pl").Click();
            Sleep(2.0); // Replace with WaitForAjaxComplete

            return new WikiMainPage(webDriver);
        }
    }
}
