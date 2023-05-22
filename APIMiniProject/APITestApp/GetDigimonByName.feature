Feature: GetDigimonByName

Happy and Sad paths for getting a Digimon by their name

Background: 
	Given I have initialised the Digimon Service

@Happy
@Developer
Scenario: Request for valid Digimon by Name returns valid status
	When I make request with Digimon Name <"Koromon">
	Then I should get a response with no errors and status 200

	@Sad
@Developer
Scenario: Request for invalid Digimon by Name returns invalid status
	When I make request with Digimon Name <"Tony">
	Then I should get a response with status "400"
	And errorMsg containing "not a Digimon in our database"

@Happy
@User
Scenario: Request for valid Digimon by Name returns valid Digimon from database
	When I make request with Digimon Name <"Koromon">
	Then I should get a response with the name, image and level