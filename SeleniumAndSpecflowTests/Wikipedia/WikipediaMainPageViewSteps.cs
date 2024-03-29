﻿using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using SeleniumAndSpecflowPageModel.Wikipedia;
using SeleniumAndSpecflowTests.Base;
using SeleniumAndSpecflowTests.JsonSettings;
using TechTalk.SpecFlow;

namespace SeleniumAndSpecflowTests.Wikipedia
{
    [Binding]
    public class WikipediaMainPageViewSteps : SpecFlowHooks
    {
        private static TestsSettings settings = new TestsSettings(TestData.JsonSettings.WikipediaSettings);

        public WikipediaMainPageViewSteps() : base(settings)
        {
        }

        [BeforeScenario("@wikipedia")]
        public void BeforeWikipediaScenario()
        {
            SetUp();
        }

        [AfterScenario("@wikipedia")]
        public void AfterScenario()
        {
            CleanUp();
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
            wikiWelcomePage.GoToPolishWikipediaByAllLanguages();
        }

        [Then(@"Wikipedia in polish language will be displayed")]
        public void ThenWikipediaInPolishLanguageWillBeDisplayed()
        {
            var wikiMainPage = new WikipediaMainPage(webDriver);
            Assert.IsTrue(wikiMainPage.IsLoaded());
        }

        [Then(@"Wikipedia Article for (.*) is displayed")]
        public void ThenWikipediaArticleForIsDisplayed(string searchPhrase)
        {
            var wikipediaArticlePage = new WikipediaArticlePage(webDriver);
            Assert.IsTrue(wikipediaArticlePage.IsLoaded());
            Assert.IsTrue(wikipediaArticlePage.ReturnArticleHeader().Contains(searchPhrase));
        }
    }
}
