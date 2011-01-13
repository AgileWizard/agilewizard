Feature: Resource
	In order to manage resources
	As a admin
	I should be able to add/edit a resource onto website

Scenario: Add and edit Resource
	Given login already
	And open adding-resource page
	And enter data in resource page
		| Field			| Value								|
		| Title			| Embeded Video						|
		| Content		| Created Content					|
		| Author		| Daniel							|
		| ReferenceUrl	| http://www.cnblogs.com/tengzy/	|
		| Tags 			| Agile,Shanghai					|
	And press submit button
	Then current page should be resource details page
		| Field			| Value								|
		| Title			| Embeded Video						|
		| Content		| Created Content					|
		| Author		| Daniel							|
		| ReferenceUrl	| http://www.cnblogs.com/tengzy/	|
		| Tags 			| Agile,Shanghai					|
