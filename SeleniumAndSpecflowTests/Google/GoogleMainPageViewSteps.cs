using NUnit.Framework;
using SeleniumAndSpecflowTests.Base;
using SeleniumAndSpecflowTests.JsonSettings;
using TechTalk.SpecFlow;

namespace SeleniumAndSpecflowTests.Google
{
    [Binding]
    public class GoogleMainPageViewSteps : SpecFlowTestsBase
    {
        private static TestsSettings googleSettings = new TestsSettings(TestData.JsonSettings.GoogleSettings);

        public GoogleMainPageViewSteps() : base(googleSettings)
        {
        }

        [Given(@"Main Google Page is presented")]
        public void GivenMainGooglePageIsPresented()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"(.*) is entered")]
        public void WhenIsEntered(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Results for (.*) on Google Results page should be displayed")]
        public void ThenResultsForOnGoogleResultsPageShouldBeDisplayed(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
