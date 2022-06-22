using OpenQA.Selenium;
using SeleniumAndSpecflowPageModel.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumAndSpecflowPageModel.Wikipedia
{
    public class WikipediaMainPage : PageObject
    {
        public WikipediaMainPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        private IWebElement mainPage => webDriver.FindElement(By.XPath("//*[@id='content'][@class='mw-body']"));
        
        public override bool IsLoaded()
        {
            return IsElementDisplayed(mainPage);
        }
    }
}
