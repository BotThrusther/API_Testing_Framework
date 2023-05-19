Feature: GetDigimonDatabase

As a developer
I want to see all the Digimon currently stored in the database
So that I know which Digimon are available to query


@Happy
Scenario: Retrieve all Digimon in the database returns correct status code
Given I have a valid API endpoint, https://digimon-api.vercel.app/api/digimon
When I make an API call
Then I should get a response with no errors and status 200

@Sad
Scenario: Retrieve no Digimon in the database
Given I have a invalid API endpoint, https://digimon-api.herokuapp.com/api/digimon
When I make an API call 
Then I should get a response with an error not found and status 404

@Happy
Scenario: Return all Digimon in database
Given I have a valid API endpoint,
When I make an API call
Then I should receive a list of all the digimons currently in the database