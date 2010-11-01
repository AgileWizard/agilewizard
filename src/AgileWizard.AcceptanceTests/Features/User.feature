Feature: User
	In order to indentify user
	As a website master
	I want user to login with username and password

@ignore
Scenario: Login
	Given I open login page
	And I enter username - 'agilewizard' and password - 'agilewizard'
	When I press login
	Then I should be redirected to main page
