Feature: US0004
Scenario: 1
	Given an nutritionist
	When he starts registering
	Then the system will ask for his information
Scenario: 2 and 3
	Given an nutritionist
	When he registers incorrectly
	Then the system will show an error message and not register the nutritionist
Scenario: 4
	Given an nutritionist
	When he registers correctly
	Then the system will show the registering form, waiting validations
Scenario: 5
	Given an nutritionist
	When he accept the registering form
	Then the system will send a confirmation