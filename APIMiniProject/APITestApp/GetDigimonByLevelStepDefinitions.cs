using APIClientApp.PostcodeIOService;
using System;
using System.Drawing;
using System.Reflection.Emit;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Bindings;

namespace APITestApp
{
    [Scope(Feature = "GetDigimonByLevel")]
    [Binding]
    public class GetDigimonByLevelStepDefinitions
    {
        private static DigimonService _digiService;
        [Given(@"I have initialised the Digimon Service")]
        public void GivenIHaveInitialisedTheDigimonService()
        {
            _digiService = new DigimonService();
        }

        [When(@"I make a request for ""([^""]*)"" level Digimon")]
        public async Task WhenIMakeARequestForLevelDigimon(string level)
        {
            await _digiService.MakeRequestAsync($"/level/{level}");
        }

        [Then(@"the json body should Digimon of ""([^""]*)"" level")]
        public void ThenTheJsonBodyShouldDigimonOfLevel(string level)
        {
            Assert.That(_digiService.IsOnlyLevel(level));
            Assert.That(_digiService.DigimonJResponse, Is.Not.Empty);
        }

        [When(@"I make a request for any valid level of Digimon")]
        public async Task WhenIMakeARequestForAnyValidLevelOfDigimon()
        {
            await _digiService.MakeRequestAsync($"/level/ultimate");
        }

        [When(@"I make a request for an invalid Digimon level")]
        public async Task WhenIMakeARequestForAnInvalidDigimonLevel()
        {
            await _digiService.MakeRequestAsync($"/level/invalidLevel");
        }

        [Then(@"the response should have Status code (.*)")]
        public void ThenTheResponseShouldHaveStatusCode(int expected)
        {
            Assert.That(_digiService.GetStatusCode(), Is.EqualTo(expected));
        }

    }
}
