Feature: GoogleMainPageView
	Experimental Feature to check possibilities of merging Selenium POM and Specflow tests, tests done on Google

	@google
Scenario: Should search for result on Main Google page
	Given Main Google Page is presented
	When Search <phrase> is entered
	Then Results for <phrase> on Google Results page should be displayed
	Examples: 
	| phrase		|
	| Star Wars     |
	| Skyrim        |

	@google
Scenario: Should search for image on Google page
	Given Main Google Page is presented
	When Switched to Image Search page
	When Image path is entered
	Then Results for Image on Google Search Image Results page should be displayed
 
	@google
Scenario: Should search for result on Main Google page and enter Wikipedia Article
	Given Main Google Page is presented
	When Search <phrase> is entered
	And On Search Results list Wikipedia Article for <phrase> is selected
	Then Wikipedia Article for <phrase> is displayed
	Examples: 
	| phrase		|
	| Skyrim        |