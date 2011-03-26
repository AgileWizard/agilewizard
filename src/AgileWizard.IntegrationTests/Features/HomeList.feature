Feature: Resource lists at Homepage
	In order to see resources of most attention
	As a visitor
	I want to see top like, top hit and latest resource on Homepage

Scenario: top like resource list
	# like # descending
	Given there are 2 pages of resources
	When I wait for non-stale data
	When I see top like resources
	Then there will be 3 resources on the page
	And order by like desc

Scenario: top hit resource list
	# hit # descending
	Given there are 2 pages of resources
	When I wait for non-stale data
	When I see top hit resources
	Then there will be 3 resources on the page
	And order by hit desc
