Feature: JourneyPlanner
	
Scenario Outline: 01_verify that a customer can plan a journey with valid locations
	Given that TFL Website is successfully launched
	When a customer enters valid from "<From>" and to "<To>" Locations
	And a customer clicks on plan my Journey
	Then the result page should display Journey results
	And the result page should have "<From>" and "<To>" displayed
	Examples:
	| From          | To        |
	| SE18 4QH      | SE18 5NR  |
	| London Bridge | Stockwell |

Scenario: 02_verify that a customer cannot plan a journey with invalid location
	Given that TFL Website is successfully launched
	When a customer enters valid from "SE11 4XX" and to "SE18 5NR" Locations
	And a customer clicks on plan my Journey
	Then the result page should display Journey results
	And the error message Sorry, we can't find a journey matching your criteria should be displayed
	

Scenario Outline: 03_verify that a customer cannot plan a journey without Locations
	Given that TFL Website is successfully launched
	When a customer enters valid from "<From>" and to "<To>" Locations
	And a customer clicks on plan my Journey
	Then an error message "<ErrorMessage>" should be displayed
	Examples:
	| Scenarios            | From     | To       | ErrorMessage                |
	| Empty From Locations |          | SE18 5NR | The From field is required. |
	| Empty To Locations   | SE18 4QH |          | The To field is required.   |
	

Scenario: 04_verify that a customer can edit a journey from the results
	Given that TFL Website is successfully launched
	When a customer enters valid from "SE18 4QH" and to "SE18 5NR" Locations
	And a customer clicks on plan my Journey
	Then the result page should display Journey results
	And the result page should have "SE18 4QH" and "SE18 5NR" displayed
	When a customer clicks on edit journey link
	And a customer inputs "Vauxhall" and "Ealing Broadway" as new from and to journey data
	When a customer clicks on update Journey
	Then the result page should have "Vauxhall" and "Ealing Broadway" displayed
	
	
Scenario: 05_verify that a customer can view Recent Journey details
	Given that TFL Website is successfully launched
	When a customer enters valid from "SE18 4QH" and to "SE18 5NR" Locations
	And a customer clicks on plan my Journey
	Then the result page should display Journey results
	And the result page should have "SE18 4QH" and "SE18 5NR" displayed
	And a user is able to see a list of journeys SE18 4QH and SE18 5NR
	