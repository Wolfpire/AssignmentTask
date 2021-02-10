Feature: User login

Scenario: Character validation
Given user is on login page
And user types in invalid username characters
And user types in invalid password characters
When user confirms input data
Then tooltip1 is shown
And  tooltip2 is shown

Scenario: Username does not exist
Given user is on login page
And user types in valid characters in username
And user types in valid characters in password
But username does not exist in database
When user confirms input data
Then tooltip3 is shown

Scenario: Password does not exist
Given user is on login page
And user types in valid characters in username
And user types in valid characters in password
But password does not exist in database
When user confirms input data
Then tooltip3 is shown

Scenario: User logs in sucessfully
Given user is on login page
And user types in username
And user types in password
And username and password matches
When user confirms input data
Then user is authorized

Scenraio: User exceeds number of attempts
Given user is on login page
And user types in username
And user types in password
And password does not match
And user confirms input data
And user types in password in attempt2
And password does not match
And user confirms input data
And user types in password in attempt3
And password does not match
When user confirms input data
Then users account is blocked




Feature: User registration

Scenario: Username exists
Given user is on registration page
And user enters valid username
And user enters valid password
And user enters confirmation password correctly
But username exits in database
When user confirms entered data
Then tooltip4 is shown

Scenario: Password exists
Given user is on registration page
And user enters valid username
And user enters valid password
And user enters confirmation password correctly
But password exits in database
When user confirms entered data
Then tooltip5 is shown

Scenario: Passwords do not match
Given user is on registration page
And user enters valid username
And user enters valid password
But user enter different valid confirmation password
When user confirms entered data
Then tooltip6 is shown


Scenarios I would automate:
[Character validation]
[Passwords do not match]
[User logs in sucessfully]
[User exceeds number of attempts]
These scenarios are covered by data that we know for sure whether they are valid or not and also can be run multiple times.

For the other test scenarios we are unsure what the result we'll be based on the entered data as it's now. To solve this, the tescases must be integrated to the level where it can create the data first and then used them as an input in the test above. Another approach could be manual test with checked and prepared data beforehand.
