using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumAndSpecflowTests.Base
{
    public abstract class TestsBase
    {
        protected IWebDriver webDriver;
        private readonly Browser browser; 
        private readonly string url;
        private readonly bool headlessMode;
        private readonly bool fullscreenMode;
        private readonly int implicitWait;
        
        protected TestsBase(TestsSettings settings)
        {
            this.browser = settings.Browser; 
            this.url = settings.Url;
            this.headlessMode = settings.HealdessMode;
            this.fullscreenMode = settings.FullScreenMode;
            this.implicitWait = settings.ImplicitWait;
        }

        [SetUp]
        protected void SetUp()
        {
            webDriver = new WebDriverBuilder()
                //.WithDownloadLocation(downloadsLocation)
                .OfType(browser)
                .RunInMaximizedWindow(fullscreenMode)
                .InHeadlessMode(headlessMode)
                .ImplicitWait(implicitWait)
                .Build();
            GoToUrl(url);
        }

        [TearDown]
        protected void CleanUp()
        {
            TearDownCleanUp();
        }

        protected void GoToUrl(string url)
        {
            Console.WriteLine($"Go to URL = {url}");
            webDriver.Navigate().GoToUrl(url);
        }

        protected void TearDownCleanUp()
        {
            Console.WriteLine("Delete Cookies");
            try
            {
                webDriver.Manage().Cookies.DeleteAllCookies();
            }
            catch { }

            try
            {
                webDriver.Close();
            }
            catch { }

            Console.WriteLine("Close browser");
            try
            {
                webDriver.Quit();
            }
            catch { }
        }
    }
}
