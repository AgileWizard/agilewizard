Feature: Resource lists at Homepage
	In order to see resources of most attention
	As a visitor
	I want to see top like, top hit and latest resource on Homepage

@Ignore
Scenario: top like resource list
	# like # descending
	Given there are 2 pages of resources
	When I see top like resources
	Then there will be 3 resources on the page
	And order by like desc
