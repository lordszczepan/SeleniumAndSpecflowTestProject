using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumAndSpecflowTests.Base
{
    internal class WebDriverBuilder
    {
        private IWebDriver driver;
        private Browser type;
        private string url;
        private bool maximizeWindow;
        private bool headlessMode;
        private int implicitWaitTime;
        private string downloadPath;

        public WebDriverBuilder OfType(Browser type)
        {
            this.type = type;
            return this;
        }

        public WebDriverBuilder WithDownloadPath(string downloadPath)
        {
            this.downloadPath = downloadPath;
            return this;
        }

        public WebDriverBuilder RunInMaximizedWindow(bool maximizeWindow)
        {
            this.maximizeWindow = maximizeWindow;
            return this;
        }

        public WebDriverBuilder InHeadlessMode(bool headlessMode)
        {
            this.headlessMode = headlessMode;
            return this;
        }

        public WebDriverBuilder ImplicitWait(int implicitWaitTime)
        {
            this.implicitWaitTime = implicitWaitTime;
            return this;
        }

        public IWebDriver Build()
        {
            switch (type)
            {
                case Browser.Chrome:
                    ChromeOptions options = new ChromeOptions();
                    options.AddUserProfilePreference("download.default_directory", @$"{downloadPath}\");
                    options.AddUserProfilePreference("download.prompt_for_download", false);
                    options.AddUserProfilePreference("safebrowsing.disable_download_protection", true);
                    options.AddUserProfilePreference("profile.default_content_setting_values.automatic_downloads", 1);
                    options.AddArguments("enable-automation");
                    options.AddArguments("--no-sandbox");
                    options.AddArguments("--disable-extensions");
                    options.AddArguments("--dns-prefetch-disable");
                    options.AddArguments("--disable-gpu");
                    options.PageLoadStrategy = PageLoadStrategy.Normal;
                    if (headlessMode)
                    {
                        options.AddArgument("--headless");
                        options.AddArgument("window-size=1200,1000");
                    }
                    driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromSeconds(300));
                    break;
                //case WebDriverType.Firefox:
                //    driver = new FirefoxDriver();
                //    break;
                //case WebDriverType.IE:
                //    driver = new InternetExplorerDriver();
                //    break;
                //case WebDriverType.Edge:
                //    driver = new EdgeDriver();
                //    break;
            }

            TimeSpan time = TimeSpan.FromSeconds(implicitWaitTime);
            driver.Manage().Timeouts().ImplicitWait = time;

            if (maximizeWindow)
                driver.Manage().Window.Maximize();

            return driver;
        }
    }
}
