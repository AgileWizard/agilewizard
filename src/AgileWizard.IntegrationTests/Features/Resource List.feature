Feature: Resource List
	As a visitor
	I want to see  list of resources

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
	Then resource list of tag 'Coding-Dojo' should have 1 item

Scenario: resource list paging single page
	Given there are 1 pages of resources
	When I wait for non-stale data
	Then there will be 1 resources on the page

Scenario: resource list paging multiple page
	Given there are 2 pages of resources
	When I wait for non-stale data
	Then there will be 20 resources on the page
	Then there will be 1 more resources on the page

@Ignore
Scenario: tag list should support paging
	#two pages of resources with tag "Agile"
	Given there are 2 pages of resources
	When I wait for non-stale data
	Then there will be 20 resources on the tag list
	When next page
	Then there will be 1 more resources the tag list






