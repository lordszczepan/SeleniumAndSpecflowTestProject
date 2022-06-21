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
        private WebDriverType type;
        private string url;
        private string downloadsLocation;
        private bool maximizeWindow;
        private bool headlessMode;

        public WebDriverBuilder OfType(WebDriverType type)
        {
            this.type = type;
            return this;
        }

        public WebDriverBuilder WithUrl(string url)
        {
            this.url = url;
            return this;
        }

        //public WebDriverBuilder WithDownloadLocation(string downloadsLocation)
        //{
        //    this.downloadsLocation = downloadsLocation;
        //    return this;
        //}

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

        public IWebDriver Build()
        {
            switch (type)
            {
                case WebDriverType.Chrome:
                    ChromeOptions options = new ChromeOptions();
                    //options.AddUserProfilePreference("download.default_directory", $@"{downloadsLocation}\");
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

            driver.Url = url;

            if (maximizeWindow)
                driver.Manage().Window.Maximize();

            TimeSpan time = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().ImplicitWait = time;

            return driver;
        }
    }
}
