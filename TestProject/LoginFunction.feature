Feature: To test the Login Functionality of the Turn Up site

  Scenario: Successful login

    Given I'm on the login Page
    When I enter credentials hari and 123123 and click login button
    Then Verify I'm on Home Page


  Scenario: Unsuccessful login

    Given I'm on the login Page
    When I enter credentials hari and 12312 and click login button
    Then I can see Error message displayed

