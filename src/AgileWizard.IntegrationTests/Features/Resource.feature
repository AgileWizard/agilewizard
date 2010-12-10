Feature: Add Resource
	As a admin, 
	I should be able to record the title, content and author

Scenario: Add simple resources
	Given new resource with  title - 'simple Resource' and content - 'simple Content' and author - 'Test Author'
	When submit resource to system
	Then resource will be persisted
	And navigate to index page
