Feature: WikipediaMainPageView
	Experimental Feature to check possibilities of merging Selenium POM and Specflow tests

Scenario: Should enter Polish Wikipedia Main Page
	Given Welcome Wikipedia Page is presented
	When Polish Version of Wikipedia will be selected
	Then Wikipedia in polish language will be displayed