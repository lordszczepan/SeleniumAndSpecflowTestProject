﻿using NUnit.Framework;
using SeleniumAndSpecflowPageModel.Google;
using SeleniumAndSpecflowPageModel.Wikipedia;
using SeleniumAndSpecflowTests.Base;
using SeleniumAndSpecflowTests.JsonSettings;
using TechTalk.SpecFlow;

namespace SeleniumAndSpecflowTests.Google
{
    [Binding]
    public class GoogleMainPageViewSteps : SpecFlowHooks
    {
        private static TestsSettings settings = new TestsSettings(TestData.JsonSettings.GoogleSettings);

        public GoogleMainPageViewSteps() : base(settings)
        {
        }

        [BeforeScenario("@google")]
        public void BeforeGoogleScenario()
        {
            SetUp();
        }

        [AfterScenario("@google")]
        public void AfterScenario()
        {
            CleanUp();
        }

        [Given(@"Main Google Page is presented")]
        public void GivenMainGooglePageIsPresented()
        {
            var googleMainPage = new GoogleMainPage(webDriver);
            Assert.IsTrue(googleMainPage.IsLoaded());
        }

        [When(@"Search (.*) is entered")]
        public void WhenIsEntered(string searchPhrase)
        {
            var googleMainPage = new GoogleMainPage(webDriver);
            googleMainPage.SearchForPhrase(searchPhrase);
        }

        [When(@"Switched to Image Search page")]
        public void WhenSwitchedToImageSearchPage()
        {
            var googleMainPage = new GoogleMainPage(webDriver);
            var googleMainImagesPage = googleMainPage.Sidebar.GoToImages();
            Assert.IsTrue(googleMainImagesPage.IsLoaded());
        }

        [When(@"Image path is entered")]
        public void WhenImagePathIsEntered()
        {
            var googleMainImagesPage = new GoogleMainImagesPage(webDriver);
            var googleSearchImageResultsPage = googleMainImagesPage.SearchByImagePath("C:\\Files\\Images\\Test1#.jpg");
        }

        [Then(@"Results for Image on Google Search Image Results page should be displayed")]
        public void ThenResultsForImageOnGoogleSearchImageResultsPageShouldBeDisplayed()
        {
            var googleSearchImageResultsPage = new GoogleSearchImageResultsPage(webDriver);
            Assert.IsTrue(googleSearchImageResultsPage.IsLoaded());
        }
    }
}
