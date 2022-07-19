using NUnit.Framework;
using SeleniumAndSpecflowPageModel.Wikipedia;
using SeleniumAndSpecflowTests.Base;
using SeleniumAndSpecflowTests.JsonSettings;
using TechTalk.SpecFlow;

namespace SeleniumAndSpecflowTests.Wikipedia
{
    [Binding]
    public class WikipediaMainPageViewSteps : SpecFlowTestsBase
    {
        private static TestsSettings wikipediaSettings = new TestsSettings(TestData.JsonSettings.WikipediaSettings);

        public WikipediaMainPageViewSteps() : base(wikipediaSettings)
        {
        }

        [Given(@"Welcome Wikipedia Page is presented")]
        public void GivenWelcomeWikipediaPageIsPresented()
        {
            var wikiWelcomePage = new WikipediaWelcomePage(webDriver);
            Assert.IsTrue(wikiWelcomePage.IsLoaded());
        }

        [When(@"Polish Version of Wikipedia will be selected")]
        public void WhenPolishVersionOfWikipediaWillBeSelected()
        {
            var wikiWelcomePage = new WikipediaWelcomePage(webDriver);
            wikiWelcomePage.GoToPolishWikipedia();
        }

        [Then(@"Wikipedia in polish language will be displayed")]
        public void ThenWikipediaInPolishLanguageWillBeDisplayed()
        {
            var wikiMainPage = new WikipediaMainPage(webDriver);
            Assert.IsTrue(wikiMainPage.IsLoaded());
        }
    }
}
