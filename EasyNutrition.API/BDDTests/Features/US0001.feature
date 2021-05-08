Feature: US0001
Scenario: 1
	Given an administrator logged in	
	When loads the subscriptions section
	Then the system will display all the plans
Scenario: 2
	Given an administrator logged in
	When loads the subscriptions section
	Then the system will display the detail of that subscription
Scenario: 3
	Given an administrator logged in
	When loads the subscriptions section
	Then he can create a new subscription
Scenario: 4
	Given an administrator logged in
	When creating a new new subscription a field is completed wrong
	Then the system should show a error message
Scenario: 5
	Given an administrator logged in
	When he delete a subscription
	Then the system should show a warning message