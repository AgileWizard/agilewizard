Feature: Resource
	In order to manage resources
	As a admin
	I should be able to add/edit a resource onto website

Scenario: Add and edit Resource
	Given login already
	And open adding-resource page
	And enter data in resource page
		| Field			| Value								|
		| Title			| Test Embeded Video				|
		| Content		| Created Content					|
		| Author		| Daniel							|
		| ReferenceUrl	| http://www.cnblogs.com/tengzy/	|
		| Tags 			| Agile,Shanghai					|
	And press submit button
	Then current page should be resource details page
		| Field			| Value								|
		| Title			| Test Embeded Video				|
		| Content		| Created Content					|
		| Author		| Daniel							|
		| ReferenceUrl	| http://www.cnblogs.com/tengzy/	|
		| Tags 			| Agile,Shanghai					|
	Then open resource list page and validate culture and total count
	Then go resource edit page with title - Test Embeded Video
	Then update resource data
		| Field			| Value								|
		| Title			| Modified Title					|
		| Content		| Modified Content					|
		| Author		| Test Author						|
		| ReferenceUrl	| http://testurl.com/				|
		| Tags 			| TestTag							|
	Then press submit button
	Then page should be redirected to details page
		| Field			| Value								|
		| Title			| Modified Title					|
		| Content		| Modified Content					|
		| Author		| Test Author						|
		| ReferenceUrl	| http://testurl.com/				|
		| Tags 			| TestTag							|
	Then go to resource list of tag 'TestTag'
	Then Then resource list of tag 'TestTag' should have 1 item
