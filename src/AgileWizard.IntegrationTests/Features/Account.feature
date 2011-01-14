Feature: Account Login
	As a website master
	I can login to system

Scenario: Successful login
	When logon with correct username and password
	Then navigate to home page

Scenario Outline: Failure login 
	When logon username - <username> and password - <password>
	Then no navigation
	Then show error message

	Examples:
	|   username   |  password  |
	| notexisting  | agilewizard|
	| agilewizard |  wrongone  |