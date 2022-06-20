using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumAndSpecflowTestProject.Base
{
    public abstract class PageObject
    {
        protected readonly IWebDriver webDriver;

        public PageObject(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public abstract bool IsLoaded();
    }
}
