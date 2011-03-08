Feature: Account
	In order to manage accounts
	As an admin
	I should be able to add/inactive account onto website

@mytag
Scenario: Add User
	Given login already
	And open adding-user page
	And enter data in account page
	| Field			| Value							|
	| UserName			| testaccount					|
	| Password		| testpassword					|
	Then press submit button to create user
	Then logout the current account
	Then open login page
	Then input account name and password
	| Field			| Value							|
	| UserName			| testaccount					|
	| Password		| testpassword					|
	Then login successfully