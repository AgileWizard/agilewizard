Feature: Account - NonUI
	In order to indentify user
	As a website master
	I want user to login with username and password

Scenario: Login
	Given new account controller
  When logon with username - 'agilewizard' and password - 'agilewizard'
	Then return result should have controller - 'home' and action - 'index'
