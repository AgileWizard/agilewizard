Feature: List Resource By Tag
	As a website user
	I want to see resources by given tag

Scenario: Group resource by tag
	Given there is a resource
	|	Field			|	Value					|
	|	Title			|	TDD Training Course		|
	|	Content			|	Test-driven development	|
	|	Author			|	Steven Zhang			|
	|	Tags			|	TDD						|
	When I wait for non-stale data
	Then the tag list should contain 'TDD' tag


Scenario: List resources by given tag
	Given there is a resource
	|	Field			|	Value				|
	|	Title			|	Coding Dojo			|
	|	Content			|	Coding Dojo is hot	|
	|	Author			|	Steven Zhang		|
	|	Tags			|	coding-dojo			|
	When I wait for non-stale data
	Then resource list of tag 'coding-dojo' should have 1 item

