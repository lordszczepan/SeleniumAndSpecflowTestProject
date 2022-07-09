using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
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
        private readonly string downloadPath;

        protected TestsBase(TestsSettings settings)
        {
            this.browser = settings.Browser; 
            this.url = settings.Url;
            this.headlessMode = settings.HealdessMode;
            this.fullscreenMode = settings.FullScreenMode;
            this.implicitWait = settings.ImplicitWait;
            this.downloadPath = settings.DownloadPath;
        }

        [SetUp]
        protected void SetUp()
        {
            webDriver = new WebDriverBuilder()
                .WithDownloadPath(downloadPath)
                .OfType(browser)
                .RunInMaximizedWindow(fullscreenMode)
                .InHeadlessMode(headlessMode)
                .ImplicitWait(implicitWait)
                .Build();
            GoToUrl(url);
            PrepareDownloadFolder();
        }

        [TearDown]
        protected void CleanUp()
        {
            TearDownRemoveAllScreenshots();
            TearDownCleanDownloadPath();
            TearDownCleanUp();
        }

        protected void GoToUrl(string url)
        {
            Console.WriteLine($"SetUp: Go to URL = {url}");
            webDriver.Navigate().GoToUrl(url);
        }

        protected void PrepareDownloadFolder()
        {
            Console.WriteLine("SetUp: Prepare download path");
            if (!File.Exists(downloadPath))
            {
                Directory.CreateDirectory(downloadPath);
            }
        }

        protected void TakeScreenshot(ScreenshotImageFormat imageFormat = ScreenshotImageFormat.Png, int fileNr = 1)
        {
            string screenshotPath = $@"{downloadPath}\Screenshots";
            string screenshotName = "Screenshot";
            string imageExtension = "";
            switch (imageFormat)
            {
                case ScreenshotImageFormat.Bmp:
                    imageExtension = "bmp";
                    break;
                case ScreenshotImageFormat.Gif:
                    imageExtension = "gif";
                    break;
                case ScreenshotImageFormat.Jpeg:
                    imageExtension = "jpeg";
                    break;

                // Only Image Format that is supported by .Net Core
                case ScreenshotImageFormat.Png:
                    imageExtension = "png";
                    break;
                case ScreenshotImageFormat.Tiff:
                    imageExtension = "tiff";
                    break;
            }

            string screenshotFilePath = $@"{screenshotPath}\{screenshotName}({fileNr}).{imageExtension}";

            Screenshot screenshot = ((ITakesScreenshot)webDriver).GetScreenshot();

            if (!File.Exists(screenshotPath))
            {
                Directory.CreateDirectory(screenshotPath);
            }

            if (File.Exists(screenshotFilePath))
            {
                TakeScreenshot(imageFormat, fileNr + 1);
            }
            else
            {
                Console.WriteLine($"Screenshot: Taking screenshot: '{screenshotFilePath}'");
                screenshot.SaveAsFile(screenshotFilePath, imageFormat);
            }
        }

        protected void TearDownCleanUp()
        {
            Console.WriteLine("TearDown: Delete Cookies");
            try
            {
                webDriver.Manage().Cookies.DeleteAllCookies();
            }
            catch { }

            Console.WriteLine("TearDown: Close browser");
            try
            {
                webDriver.Close();
            }
            catch { }
        }

        private void TearDownCleanDownloadPath()
        {
            Console.WriteLine("TearDown: Clean download path");
            string filePath = $@"{downloadPath}\";
            var files = new DirectoryInfo(filePath).GetFiles();
            int filesCount = files.Length;

            if (filesCount != 0)
            {
                foreach (FileInfo file in files)
                {
                    Console.WriteLine($"TearDown: Delete file: '{file.ToString()}'");
                    File.Delete(filePath + file.Name);
                }
            }
        }

        protected void TearDownRemoveAllScreenshots()
        {
            string screenshotPath = $@"{downloadPath}\Screenshots\";
            
            if (Directory.Exists(screenshotPath))
            {
                var screenshots = new DirectoryInfo(screenshotPath).GetFiles();

                if (screenshots.Length != 0)
                {
                    foreach (FileInfo screenshot in screenshots)
                    {
                        Console.WriteLine(@$"TearDown: Delete screenshot: '{screenshotPath}{screenshot.Name}'");
                        File.Delete(screenshotPath + screenshot.Name);
                    }
                }
            }
        }
    }
}
