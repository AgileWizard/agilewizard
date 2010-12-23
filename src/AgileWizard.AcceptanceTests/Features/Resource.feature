﻿Feature: Resource
	In order to manage resources
	As a admin
	I should be able to add/edit a resource onto website

Scenario: Add Simple Resource
	Given login already
	And open adding-resource page
	And enter data in resource page
		| Field			| Value								|
		| Title			| Embeded Video						|
		| Content		| Modified Content					|
		| Author		| Daniel							|
		| ReferenceUrl	| http://www.cnblogs.com/tengzy/	|
		| Tags 			| Agile,Shanghai					|

	When press submit button
	Then resource details page should be shown

Scenario: Edit A Resource
	Given login already
	And open resource list page
	And edit a resource titled with 'Embeded Video'
	And enter data in resource page
		| Field			| Value								|
		| Title			| Embeded Video						|
		| Content		| Modified Content					|
		| Author		| Daniel							|
		| ReferenceUrl	| http://www.cnblogs.com/tengzy/	|

	When press submit button
	Then resource details page should be shown

Scenario: Add Resource require login
	Given no login
	And open adding-resource page
	Then login page should be open

Scenario: View Resource Detail
	Given open resource list page
	When open a resource titled with 'Embeded Video'
	Then resource details page title with - 'Embeded Video' should be shown

Scenario: View Resource List
	Given login already
	And open resource list page
	Then resoure list page should be in current culture



