using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SeleniumAndSpecflowTests.Base
{
    public class SpecFlowTestsBase : TestsBase
    {
        public SpecFlowTestsBase(TestsSettings settings) : base(settings)
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
