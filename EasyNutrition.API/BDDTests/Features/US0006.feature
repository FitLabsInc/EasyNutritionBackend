Feature: US0006
    Scenario: 1
        Given a nutritionist logged in
        When he goes to patient section
        Then the system should show which patients had an appointment and their data
    Scenario: 2
        Given a nutritionist is in patient section
        When he clicks into a patient
        Then the system should show detailed data from the patient and its respective appointments
    Scenario: 3
        Given a nutritionist is in patient section
        When he clicks into report advances
        Then the system should show a form where it should fill advances and future recomendations
    Scenario: 4
        Given a nutritionist is in the fill advance report section
        When he clicks on save report
        Then the system should save the report in the data base for the patient to check it
    Scenario: 5
        Given a nutritionist is in the fill advance report section
        When he clicks on save report
        Then the system should save the report in the data base but the patient will not be able to check it