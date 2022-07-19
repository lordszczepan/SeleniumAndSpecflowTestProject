Feature: GoogleMainPageView
	Experimental Feature to check possibilities of merging Selenium POM and Specflow tests, tests done on Google

	@google
Scenario: Should search for result on Main Google page
	Given Main Google Page is presented
	When <search phrase> is entered
	Then Results for <search phrase> on Google Results page should be displayed
	Examples: 
	| search phrase |
	| Star Wars     |
	| Skyrim        |
