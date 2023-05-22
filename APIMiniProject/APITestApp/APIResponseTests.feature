Feature: APIResponseTests

Tests to determine if the API call returns the correct response
As a developer,
I want to know the response type,
So that I can code with the type correctly

Background:
Given I have initialised the Digimon Service

@Happy
@Dev
Scenario: Valid JArray when calling
	Given I have a valid API endpoint, "<endpoint>"
	When I make an API call
	Then the response should be a JArray
Examples: 
	| endpoint                  |
	| /api/digimon              |
	| /api/digimon/level/fresh  |
	| /api/digimon/name/Koromon |

@Happy
@Dev
Scenario: Valid JObject when making an invalid call
	Given I have a invalid API endpoint, "<endpoint>"
	When I make an API call
	Then the response should be a JObject
Examples: 
	| endpoint                |
	| /api/digimon            |
	| /api/digimon/level/tony |
	| /api/digimon/name/tony  |

@Sad
@Dev
Scenario: Calling the deprecated API url returns a HTML
	Given I have the URL, "https://digimon-api.herokuapp.com/api/digimon"
	When I make an API call
	Then the response should be a HTML doc
