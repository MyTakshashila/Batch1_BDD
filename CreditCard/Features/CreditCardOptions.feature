Feature: User is able to view credit card options
Scenario Outline: Ways to apply for credit card
	Given User is on the home page
	When User views the <Offerings>
	Then User is navigated to New credit card application page
Examples:
	| Offerings                |
	| Quick links - Apply now  |
	| New low rate             |
	| Easy application process |
	| Customer service         |


Scenario: Live Chat Test
	Given User is on the home page
	When User click on the Start Live Chat link
	Then Live Chat is currentily closed Popup displayed
	

