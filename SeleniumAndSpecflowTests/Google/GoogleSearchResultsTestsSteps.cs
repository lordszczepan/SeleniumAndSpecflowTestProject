using NUnit.Framework;
using SeleniumAndSpecflowPageModel.Google;
using SeleniumAndSpecflowTests.Base;
using SeleniumAndSpecflowTests.JsonSettings;
using System;
using TechTalk.SpecFlow;

namespace SeleniumAndSpecflowTests.Google
{
    [Binding]
    public class GoogleSearchResultsTestsSteps : SpecFlowHooks
    {
        private static TestsSettings settings = new TestsSettings(TestData.JsonSettings.GoogleSettings);

        public GoogleSearchResultsTestsSteps() : base(settings)
        {
        }

        [When(@"On Search Results list Wikipedia Article for (.*) is selected")]
        public void WhenOnSearchResultsListWikipediaArticleForIsSelected(string searchPhrase)
        {
            var googleSearchResultsPage = new GoogleSearchResultsPage(webDriver);
            var wikipediaArticlePage = googleSearchResultsPage.EnterWikipediaArticleBySearchResult(searchPhrase);
        }

        [Then(@"Results for (.*) on Google Results page should be displayed")]
        public void ThenResultsForOnGoogleResultsPageShouldBeDisplayed(string searchPhrase)
        {
            var googleSearchResultsPage = new GoogleSearchResultsPage(webDriver);
            Assert.AreEqual(searchPhrase, googleSearchResultsPage.ReturnSearchTextBoxValue());
        }

        [Then(@"Wikipedia Article should be on (.*) or higher")]
        public void ThenWikipediaArticleShouldBeOnOrLess(int expectedPostion)
        {
            var googleSearchResultsPage = new GoogleSearchResultsPage(webDriver);
            int displayedPostition = googleSearchResultsPage.ReturnWikipediaArticlePosition();
            Assert.LessOrEqual(displayedPostition, expectedPostion);
        }
    }
}
