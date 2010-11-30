Feature: Addition
	In order to manage resources
	As a admin
	I should be able to add/edit a resource onto website

@UI
Scenario: Add Simple Resource
	Given login already
	And open adding-resource page
	And enter title - 'simple Resource' and content - 'simple Content'
	When press button - 'Save'
	Then should be redirected to list page

@UI
Scenario: View Resource Detail
	Given there is a resource
	And open resouce page
	When click on title - ''
