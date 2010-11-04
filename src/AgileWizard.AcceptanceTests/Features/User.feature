Feature: User
	In order to indentify user
	As a website master
	I want user to login with username and password

@UI
Scenario: Login
	Given open login page
	And enter username - 'agilewizard' and password - 'agilewizard'
	When press button - 'Log On'
	Then should be redirected to main page
