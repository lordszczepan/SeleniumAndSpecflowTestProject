using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SeleniumAndSpecflowTests.Base
{
    public class TestsSettings
    {
        private Browser browser;
        private string url;
        private bool headlessMode;
        private bool fullscreenMode;
        private int implicitWait;

        //public TestsSettings(Browser browser, string url, bool headlessMode, bool fullscreenMode, int implicitWait)
        //{
        //    this.browser = browser;
        //    this.url = url;
        //    this.headlessMode = headlessMode;
        //    this.fullscreenMode = fullscreenMode;
        //    this.implicitWait = implicitWait;
        //}

        public TestsSettings(string jsonSettings)
        {
            dynamic json = JsonConvert.DeserializeObject(jsonSettings);
            this.browser = Browser.Parse(json.Browser);
            this.url = json.Url;
            this.headlessMode = json.HHeadlessMode;
            this.fullscreenMode = json.FullscreenMode;
            this.implicitWait = json.ImplicitWait;
        }

        public Browser Browser
        {
            get
            {
                Console.WriteLine($"Setting: Browser = {Enum.GetName(typeof(Browser), browser)}");
                return browser;
            }
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

        public bool FullScreenMode
        {
            get
            {
                string fullscreenModeState = fullscreenMode == true ? "On" : "Off";
                Console.WriteLine($"Setting: Fullscreen Mode = {fullscreenModeState}");
                return fullscreenMode;
            }
        }

        public int ImplicitWait
        {
            get
            {
                Console.WriteLine($"Setting: Implicit Wait = {implicitWait.ToString()}");
                return implicitWait;
            }
        }
    }
}
