Feature: BbcLogin
	In order to Login to my account 
	As a user
	I want to see my account page


Scenario Outline: Invalid password
	Given I am on the login page
	And I entered a valid <username>
	And I have entered a invalid  <password>
	When I press login
	Then I shlould see the appropriate <error>

Examples:
| username             | password                                            | error                                                                              |
| username@testing.com | 12345678                                            | Sorry, that password isn't valid. Please include a letter.                         |
| username@testing.com | 123                                                 | Sorry, that password is too short. It needs to be eight characters or more.        |
| username@testing.com | @@@@@@@                                             | Sorry, that password isn't valid. Please include a letter.                         |
| username@testing.com | aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa | Sorry, that password is too long. It can't be more than 50 characters.             |
| use                  | hsjuo82ho12                                         | That's not the right password for that account. Please try again or get help here. |                                       