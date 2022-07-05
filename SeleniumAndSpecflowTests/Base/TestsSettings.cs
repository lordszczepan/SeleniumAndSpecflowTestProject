using System;

namespace SeleniumAndSpecflowTests.Base
{
    public class TestsSettings
    {
        private Browser browser;
        private string url;
        private bool headlessMode;
        private bool fullscreenMode;
        private int implicitWait;

        public TestsSettings(string jsonSettingsPath)
        {
            var jsonConverterObject = new JsonConverter(jsonSettingsPath);
            var jsonData = jsonConverterObject.GetJsonData;
            this.url = jsonData.Settings.Url;
            string browserName = jsonData.Settings.Browser;
            this.browser = Enum.Parse<Browser>(browserName);
            this.headlessMode = jsonData.Settings.HeadlessMode;
            this.fullscreenMode = jsonData.Settings.FullscreenMode;
            this.implicitWait = jsonData.Settings.ImplicitWait;
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
