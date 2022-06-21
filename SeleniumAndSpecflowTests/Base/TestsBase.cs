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
                .WithUrl(url)
                //.WithDownloadLocation(downloadsLocation)
                .OfType(WebDriverType.Chrome)
                .RunInMaximizedWindow(false)
                .InHeadlessMode(false)
                .Build();
        }

        [TearDown]
        protected void CleanUp()
        {
            TearDownCleanUp();
        }

        protected void TearDownCleanUp()
        {
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
