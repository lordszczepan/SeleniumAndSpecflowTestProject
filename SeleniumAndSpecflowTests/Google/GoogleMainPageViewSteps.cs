﻿using NUnit.Framework;
using SeleniumAndSpecflowPageModel.Google;
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
            var googleMainPage = new GoogleMainPage(webDriver);
            Assert.IsTrue(googleMainPage.IsLoaded());
        }
        
        [When(@"(.*) is entered")]
        public void WhenIsEntered(string searchPhrase)
        {
            var googleMainPage = new GoogleMainPage(webDriver);
            googleMainPage.SearchForPhrase(searchPhrase);
        }
        
        [Then(@"Results for (.*) on Google Results page should be displayed")]
        public void ThenResultsForOnGoogleResultsPageShouldBeDisplayed(string searchPhrase)
        {
            var googleSearchResultsPage = new GoogleSearchResultsPage(webDriver);
            Assert.AreEqual(searchPhrase, googleSearchResultsPage.ReturnSearchTextBoxValue());
        }
    }
}
