﻿using NUnit.Framework;
using SeleniumAndSpecflowPageModel.Wikipedia;
using SeleniumAndSpecflowTests.Base;
using System;
using TechTalk.SpecFlow;

namespace SeleniumAndSpecflowTests.Wikipedia
{
    [Binding]
    public class WikipediaMainPageViewSteps : SpecFlowTestsBase
    {
        public WikipediaMainPageViewSteps() : base("https://www.wikipedia.org")
        {
        }

        [Given(@"Welcome Wikipedia Page is presented")]
        public void GivenWelcomeWikipediaPageIsPresented()
        {
            var wikiWelcomePage = new WikiWelcomePage(webDriver);
            Assert.IsTrue(wikiWelcomePage.IsLoaded());
        }

        [When(@"Polish Version of Wikipedia will be selected")]
        public void WhenPolishVersionOfWikipediaWillBeSelected()
        {
            var wikiWelcomePage = new WikiWelcomePage(webDriver);
            wikiWelcomePage.GoToPolishWikipedia();
        }

        [Then(@"Wikipedia in polish language will be displayed")]
        public void ThenWikipediaInPolishLanguageWillBeDisplayed()
        {
            var wikiMainPage = new WikiMainPage(webDriver);
            Assert.IsTrue(wikiMainPage.IsLoaded());
        }
    }
}