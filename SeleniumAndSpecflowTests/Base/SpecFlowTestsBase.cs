using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SeleniumAndSpecflowTests.Base
{
    public class SpecFlowTestsBase : TestsBase
    {
        public SpecFlowTestsBase(string url) : base(url)
        {
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            SetUp();
        }


        [AfterScenario]
        public void AfterScenario()
        {
            CleanUp();
        }
    }
}
