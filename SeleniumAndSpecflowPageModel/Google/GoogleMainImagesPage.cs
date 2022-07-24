using OpenQA.Selenium;
using SeleniumAndSpecflowPageModel.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumAndSpecflowPageModel.Google
{
    public class GoogleMainImagesPage : PageObject
    {
        public GoogleMainImagesPage(IWebDriver webDriver) : base(webDriver)
        {
            Sidebar = new GoogleSidebar(webDriver);
        }

        public GoogleSidebar Sidebar { get; }

        private Element imgLogo => driver.FindElement(By.XPath("//div[@class='k1zIA rSk4se']/img[@class='lnXdpd']"));

        private Element txtSearchByPhrase => driver.FindElement(By.XPath("//input[@class='gLFyf gsfi']"));

        private Element txtSearchByImage => driver.FindElement(By.XPath("//input[@id='awyMjb'][@type='file']"));

        private Element btnSearchDropDownArea => driver.FindElement(By.XPath("//div[@class='aajZCb']//input[@class='gNO89b']"));

        private Element btnSwitchToSearchingByImage => driver.FindElement(By.XPath("//*[@class='tdPRye']"));

        private Element tabSearchByUrl => driver.FindElement(By.XPath("//div[@class='WHWWB']/div[@class='iOGqzf mJEC7c']"));

        private Element tabSearchByFilePath => driver.FindElement(By.XPath("//div[@class='WHWWB']/a[@class='iOGqzf H4qWMc aXIg1b']"));

        public override bool IsLoaded()
        {
            return IsElementDisplayed(imgLogo);
        }

        public GoogleSearchImageResultsPage SearchByPhrase(string searchPhrase)
        {
            txtSearchByPhrase.TypeText(searchPhrase);

            btnSearchDropDownArea.Click();
            WaitUntilPageLoadsCompletely();

            return new GoogleSearchImageResultsPage(webDriver);
        }

        public GoogleSearchImageResultsPage SearchByImagePath(string filePath)
        {
            btnSwitchToSearchingByImage.Click();
            WaitUntilPageLoadsCompletely();

            tabSearchByFilePath.Click();

            txtSearchByImage.TypeText(filePath);
            WaitUntilPageLoadsCompletely();

            return new GoogleSearchImageResultsPage(webDriver);
        }
    }
}
