using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumAndSpecflowTests.Base
{
    public class TestsSettings
    {
        private string url;
        private bool headlessMode;
        private Browser browser;

        public TestsSettings(string url, bool headlessMode, Browser browser)
        {
            this.url = url;
            this.headlessMode = headlessMode;
            this.browser = browser;
        }

        public string Url
        {
            get
            {
                Console.WriteLine($"Setting: Url = {url}");
                return url;
            }
        }

        public bool HealdessMode
        {
            get
            {
                string headlessModeState = headlessMode == true ? "On" : "Off";
                Console.WriteLine($"Setting: Headless Mode = {headlessModeState}");
                return headlessMode;
            }
        }

        public Browser Browser
        {
            get
            {
                Console.WriteLine($"Setting: Browser = {Enum.GetName(typeof(Browser), browser)}");
                return browser;
            }
        }
    }
}
