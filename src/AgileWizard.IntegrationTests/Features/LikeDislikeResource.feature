Feature: Like/Dislike resource
	As a visitor,
	I can Like/Dislike a resource if I like/dislike it

Scenario: Like a resource
	Given there is a resource
	|	Field			|	Value							|
	|	Title			|	Resource Title					|
	|	Content			|	Resource Content				|
	|	Author			|	Jackon Zhang					|
	|	ReferenceUrl	|	http://www.neodream.info/blog	|
	|	Tags			|	Test,Integration				|
	When like the resource
	Then like number is 1
	When like the resource
	Then like number is 2

Scenario: Dislike a resource
	Given there is a resource
	|	Field			|	Value							|
	|	Title			|	Resource Title					|
	|	Content			|	Resource Content				|
	|	Author			|	Jackon Zhang					|
	|	ReferenceUrl	|	http://www.neodream.info/blog	|
	|	Tags			|	Test,Integration				|
	When dislike the resource
	Then dislike number is 1
	When dislike the resource
	Then dislike number is 2