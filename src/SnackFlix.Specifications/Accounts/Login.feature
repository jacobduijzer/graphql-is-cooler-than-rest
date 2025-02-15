Feature: use an account to login 

    @HappyPath
    Scenario: Alex uses his username and password to get a token
        Given Alex wants to login
        When he uses the username "test" and the password "test"
        Then he gets a token and is succesfully logged in