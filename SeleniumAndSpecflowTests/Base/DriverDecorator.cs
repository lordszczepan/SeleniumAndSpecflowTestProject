using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumAndSpecflowTests.Base
{
    public class DriverDecorator : Driver
    {
        protected Driver Driver;

        protected DriverDecorator(Driver driver)
        {
            Driver = driver;
        }

        public override void Quit()
        {
            Driver?.Quit();
        }

        public override void GoToUrl(string url)
        {
            Driver?.GoToUrl(url);
        }

        public override void WaitForAjax()
        {
            Driver?.WaitForAjax();
        }

        public override void WaitUntilPageLoadsCompletely()
        {
            Driver?.WaitUntilPageLoadsCompletely();
        }
    }
}
