Feature: US0007
Scenario: 1
	Given a nutritionist7 logged in succesfully
	When he enters to his profile
	Then the system will show his user data
Scenario: 2
	Given a nutritionist7 logged in succesfully
	When he is editing his profile
	Then the system will allow him to edit his photo, personal data and payment methods
Scenario: 3
	Given a nutritionist7 logged in succesfully
	When he update his profile with incorrect data
	Then the system will send error and not update his profile