using OpenQA.Selenium;
using SeleniumAndSpecflowTests.JsonSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using System.IO;

namespace SeleniumAndSpecflowTests.Base
{
    [Binding]
    public class SpecFlowHooks : TestsBase
    {

        public SpecFlowHooks(TestsSettings settings) : base(settings)
        {
        }


    }
}
