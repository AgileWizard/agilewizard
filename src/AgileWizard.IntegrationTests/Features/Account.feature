Feature: Account Login
	As a website master
	I can login to system
	And I can create other account

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

Scenario: Create a new account
	When logon with correct username and password
	And try to create a account with following value
	| Field			| Value			|
	| Email			| testaccount@gmail.com	|
	| Password		| testpassword	|
	Then create the account successfully
	Then logout the current user
	Then logon with the following account
	| Field			| Value			|
	| UserName		| testaccount@gmail.com	|
	| Password		| testpassword	|
	Then navigate to home page
