Feature: Edit resource
	As a admin,
	I can edit title, content, tag of a resource

@Ignore 
Scenario: Open a resource to edit
	Given there is a resource
	|	Field			|	Value							|
	|	Title			|	Resource Title					|
	|	Content			|	Resource Content				|
	|	Author			|	Jackon Zhang					|
	|	ReferenceUrl	|	http://www.neodream.info/blog	|
	|	Tags			|	Test,Integration				|
	When open the resource to edit
	Then navigate to edit page
	And show edit for the title, content, author and tags

@Ignore
Scenario: Edit a resource
	Given there is a resource
	|	Field			|	Value							|
	|	Title			|	Resource Title					|
	|	Content			|	Resource Content				|
	|	Author			|	Jackon Zhang					|
	|	ReferenceUrl	|	http://www.neodream.info/blog	|
	|	Tags			|	Test,Integration				|
	When modify the resource
	|	Field			|	Value							|
	|	Title			|	Modified Resource Title			|
	|	Content			|	Modified Resource Content		|
	|	Author			|	Ron Jeffries					|
	|	ReferenceUrl	|	http://xprogramming.com			|
	|	Tags			|	Test,Integration,XP				|
	Then navigate to details page
	And display the title, content, author and submit user and tags

