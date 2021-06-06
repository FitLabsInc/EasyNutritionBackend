Feature: US0005
    Scenario: 1
        Given a nutritionist logged in succesfully
        When he goes to diet section
        Then the system should show the diet list uploaded to the platform by him
    Scenario: 2
        Given a nutritionist is in the diet section
        When he clicks into upload new diet
        Then the system should show a form to fill filename, course, subject ad title; pick which stutdents to share with optionally; ad upload the resource
    Scenario: 3
        Given a nutritionist is in the diet section
        When he delete a subscription
        Then the system should show a form to fill all required data
    Scenario: 4
        Given a nutritionist is in the upload new diet form
        When he has filled all fields correctly
        Then the system should save that resource in the data base
    Scenario: 5
        Given a nutritionist is in the upload new diet form
        When he has filled all fields incorrectly
        Then the system should show an error message detailing the incorrect fields and will not create a new diet
    Scenario: 6
        Given a nutritionist is in the diet list
        When he clicks into delete a diet
        Then the system should show a confirmation window and delete the diet if he clicks into accept