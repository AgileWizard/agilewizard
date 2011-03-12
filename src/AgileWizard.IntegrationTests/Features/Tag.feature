Feature: Tag
	As a website user
	I want to see list of tags

Scenario: Tag List
	Given there is a resource
	|	Field			|	Value					|
	|	Title			|	TDD Training Course		|
	|	Content			|	Test-driven development	|
	|	Author			|	Author					|
	|	Tags			|	TagList					|
	When I wait for non-stale data
	Then tag list is available