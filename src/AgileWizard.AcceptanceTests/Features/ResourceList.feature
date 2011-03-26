Feature: Resource List
	In order to see more resources
	As a visitor
	I want to see more resources other than current page

Scenario: Default resource list
	# There is add 21 resources with tag 'Agile'
	When I go to resource list page
	Then I will see 20 resources on the page
	When I go to next page
	Then I will see 21 resources on the page

Scenario: tag resource list
	# There is add 21 resources with tag 'Agile'
	When I visit resource list of tag page
	Then I will see 20 resources on the page
	When I go to next page
	Then I will see 21 resources on the page
