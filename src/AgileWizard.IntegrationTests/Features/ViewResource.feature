Feature: View Resource
	As a visitor,
	I want to see the details of a resource.

Scenario: View a resource by id
	Given there is a resource
	|	Field			|	Value							|
	|	Title			|	Resource Title					|
	|	Content			|	Resource Content				|
	|	Author			|	Jackon Zhang					|
	|	ReferenceUrl	|	http://www.neodream.info/blog	|
	|	Tags			|	Test,Integration				|
	When view the resource
	Then display the title, content, author and submit user and tags

Scenario: Increment page view when view a resource
	Given there is a resource
	|	Field			|	Value							|
	|	Title			|	Resource Title					|
	|	Content			|	Resource Content				|
	|	Author			|	Jackon Zhang					|
	|	ReferenceUrl	|	http://www.neodream.info/blog	|
	|	Tags			|	Test,Integration				|
	When view the resource
	Then page view number should be 1
	When view the resource
	Then page view number should be 2