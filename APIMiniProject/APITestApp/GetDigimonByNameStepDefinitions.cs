using APIClientApp.PostcodeIOService;
using System;
using TechTalk.SpecFlow;

namespace APITestApp
{
    [Scope(Feature = "GetDigimonByName")]
    [Binding]
    public class GetDigimonByNameStepDefinitions
    {
        private static DigimonService _dms;

        [BeforeFeature]
        [Given(@"I have initialised the Digimon Service")]
        public static void GivenIHaveInitialisedTheDigimonService()
        {
            _dms = new DigimonService();
        }

        [When(@"I make request with Digimon Name <""([^""]*)"">")]
        public async Task WhenIMakeRequestWithDigimonName(string name)
        {
            await _dms.MakeRequestAsync($"name/{name}"); ;
        }

        [Then(@"I should get a response with no errors and status (.*)")]
        public void ThenIShouldGetAResponseWithNoErrorsAndStatus(int expected)
        {
            Assert.That((int)_dms.CallManager.DigimonResponse.StatusCode, Is.EqualTo(expected));
        }

        [Then(@"I should get a response with status ""([^""]*)""")]
        public void ThenIShouldGetAResponseWithStatus(int expected)
        {
            Assert.That((int)_dms.CallManager.DigimonResponse.StatusCode, Is.EqualTo(expected));
        }

        [Then(@"errorMsg containing ""([^""]*)""")]
        public void ThenErrorMsgContaining(string expected)
        {
            var error = _dms.DigimonResponse;
            Assert.That(error, Does.Contain(expected));
        }

        [Then(@"I should get a response with the name, image and level")]
        public void ThenIShouldGetAResponseWithTheNameImageAndLevel()
        {
            Assert.That(_dms.DigimonResponse, Does.Contain("Koromon"));
            Assert.That(_dms.DigimonResponse, Does.Contain("\"https://digimon.shadowsmith.com/img/koromon.jpg\""));
            Assert.That(_dms.DigimonResponse, Does.Contain("In Training"));

        }
    }
}
