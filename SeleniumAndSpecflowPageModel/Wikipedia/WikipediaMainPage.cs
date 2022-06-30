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

        private Element mainPage => driver.FindElement(By.XPath("//*[@id='content'][contains(@class,'mw-body')]"));
        
        public override bool IsLoaded()
        {
            return IsElementDisplayed(mainPage);
        }
    }
}
