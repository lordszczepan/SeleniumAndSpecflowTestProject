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
        private static string tekst;

        public SpecFlowHooks(TestsSettings settings) : base(settings)
        {
        }

        [BeforeTestRun]
        public static void InitializeReport()
        {
            tekst = "TEST";
            Console.WriteLine(tekst);
        }

        [BeforeFeature]
        public static void BeforeReport()
        {
            tekst = "TEST 2";
            Console.WriteLine(tekst);
        }
    }
}
