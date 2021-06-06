Feature: US0002
    Scenario 1:
        Given an administrator logged in
        When loads the postulations section
        Then the system shows the nutritionists postulations list.
    Scenario 2:
        Given an administrator logged in
        When he fills up the filters of name, DNI, date or status
        Then the system shows the data filtered
    Scenario 3:
        Given an administrator logged in
        When he accepts or denies the request
        Then the system shows a confirmation window
    Scenario 4:
        Given an administrator logged in
        When he accept the request
        Then the state of the request will be accepted and gives the nutritionist the role of nutritionist 
    Scenario 5:
        Given an administrator logged in
        When he denies a request in the postulation section
        Then the status of the request will become denied and the nutritionist cant access to the functionalities of the role nutritionist