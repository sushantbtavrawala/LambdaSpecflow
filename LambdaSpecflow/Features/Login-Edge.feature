Feature: Login application with Edge
	Testing with multiple browsers
	
@smoke
Scenario Outline: Login To Application
	Given I launch the application 
	| Browser   | 
	| <Browser> | 
	#And I click login link
	#And I enter the following details
	#| UserName | Password |
	#| admin    | password |
	#And I click login button
	#Then I should see employee details link
	#And I logout from the application

	Examples: 
	| Browser | 
	| firefox | 