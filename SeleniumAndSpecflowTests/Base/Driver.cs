using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;


namespace SeleniumAndSpecflowTests.Base
{
    public abstract class Driver
    {
        public abstract void Quit();
        public abstract void GoToUrl(string url);
        public abstract void WaitForAjax();
        public abstract void WaitUntilPageLoadsCompletely();
    }
}
