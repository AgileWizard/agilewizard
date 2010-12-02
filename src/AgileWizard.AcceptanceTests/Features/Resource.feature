Feature: Resource
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
	Given open resource list page
	When open a resource titled with 'Embeded Video'
	Then 'Embeded Video' resource details page should be open

@UI
Scenario: View Resource List
	Given login already
	And open resource list page
	Then I can see the total resouce count