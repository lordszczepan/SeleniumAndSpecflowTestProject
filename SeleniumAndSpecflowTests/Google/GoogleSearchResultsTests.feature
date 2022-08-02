Feature: GoogleSearchResultsTests
	
	@google
Scenario: Should search for phrase and display Wikipedia reference at the indicated position or higher
	Given Main Google Page is presented
	When Search <phrase> is entered
	Then Wikipedia Article should be on <expected position> or higher
	Examples: 
	| phrase | expected position |
	| Skyrim | 6                 |