Feature: GetDigimonByLevel

In order to get details of Digimon of a level
As a user
I want to be able to make a request for Digimon of level(s) on Digimon-Api

Background:
Given I have initialised the Digimon Service

@Happy
Scenario: Request for a valid Digimon level returns valid Digimon in JSON response body
	When I make a request for "rookie" level Digimon
	Then the json body should Digimon of "rookie" level

@Happy
Scenario: When valid level request is made Status code is 200 OK
	When I make a request for any valid level of Digimon
	Then the response should have Status code 200

@Sad
Scenario: When a request with an invalid is made Status code is 400 Bad request
	When I make a request for an invalid Digimon level
	Then the response should have Status code 400
