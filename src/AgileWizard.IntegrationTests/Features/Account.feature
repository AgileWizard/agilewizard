Feature: Account Login
	As a website master
	I can login to system

Scenario: Successful login
	When logon with correct username and password
	Then navigate to home page

@Ignore
Scenario: Failure login - not existing user
	When logon with non-existing username
	Then no navigation
	Then show error message

@Ignore
Scenario: Failure login - wrong password
	When logon with wrong password
	Then no navigation
	Then show error message