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
        private readonly string url;

        protected TestsBase(string url)
        {
            this.url = url;
        }

        [SetUp]
        protected void SetUp()
        {
            webDriver = new WebDriverBuilder()
                //.WithUrl(url)
                //.WithDownloadLocation(downloadsLocation)
                .OfType(Browser.Chrome)
                .RunInMaximizedWindow(false)
                .InHeadlessMode(false)
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
            Console.WriteLine("Close browser");
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

            try
            {
                webDriver.Quit();
            }
            catch { }
        }
    }
}
