Feature: Resource
	In order to manage resources
	As a admin
	I should be able to add/edit a resource onto website

@UI
Scenario: Add Simple Resource
	Given login already
	And open adding-resource page
	And enter title - 'simple Resource' and content - 'simple Content' and author - 'Daniel' 
	And tags - 'Agile,Shanghai'
	When press submit button
	Then resource details page should be shown

	@UI
Scenario: Edit A Resource
	Given login already
	And open resource list page
	And edit a resource titled with 'Embeded Video'
	And enter title - 'Embeded Video' and content - 'Modified Content' and author - 'Daniel'
	When press submit button
	Then resource details page should be shown

@UI
Scenario: Add Resource require login
	Given no login
	And open adding-resource page
	Then login page should be open

@UI
Scenario: View Resource List
	Given login already
	And open resource list page
	Then I can see the page title in current culture 
	And I can see the total resouce count
	And I can see the create resource entry in current culture
	And I can see the total resource count in current culture
	And I can see the List in current culture


