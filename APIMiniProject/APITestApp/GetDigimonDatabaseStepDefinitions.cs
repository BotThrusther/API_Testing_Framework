using APIClientApp.PostcodeIOService;
using APIClientApp.PostcodeIOService.HTTPManager;
using SpecFlow.Internal.Json;
using System;
using TechTalk.SpecFlow;

namespace APITestApp
{
    [Binding]
    [Scope(Feature = "GetDigimonDatabase")]
    public class GetDigimonDatabaseStepDefinitions
    {
        private static DigimonService _ds;
        private readonly HttpClient httpClient;


        [Given(@"I have a valid API endpoint, https://digimon-api\.vercel\.app/api/digimon")]
        public void GivenIHaveAValidAPIEndpointHttpsDigimon_Api_Vercel_AppApiDigimon()
        {
            _ds = new DigimonService();
        }

        [When(@"I make an API call")]
        public async Task WhenIMakeAnAPICall()
        {
            await _ds.MakeRequestAsync("/");
        }

        [Then(@"I should get a response with no errors and status (.*)")]
        public void ThenIShouldGetAResponseWithNoErrorsAndStatus(string expectedStatus)
        {
            Assert.That(_ds.GetStatusCode().ToString(), Is.EqualTo(expectedStatus));
        }

        [Given(@"I have a invalid API endpoint, https://digimon-api\.herokuapp\.com/api/digimon")]
        public void GivenIHaveAInvalidAPIEndpointHttpsDigimon_Api_Herokuapp_ComApiDigimon()
        {
            _ds = new DigimonService();
        }

        [Then(@"I should get a response with an error not found and status (.*)")]
        public async Task ThenIShouldGetAResponseWithAnErrorNotFoundAndStatus(string expectedStatus)
        {
            await _ds.MakeRequestAsync("jjnnj");
            Assert.That(_ds.GetStatusCode().ToString(), Is.EqualTo(expectedStatus));
        }

        [Given(@"I have a valid API endpoint,")]
        public void GivenIHaveAValidAPIEndpoint()
        {
            _ds = new DigimonService();
        }

        /*[When(@"I make the API request")]
        public async void WhenIMakeTheAPIRequest()
        {
            await _ds.MakeRequestAsync("/");
        }*/

        [Then(@"I should receive a list of all the digimons currently in the database")]
        public async Task ThenIShouldReceiveAListOfAllTheDigimonsCurrentlyInTheDatabase()
        {
            var digimonResult = _ds.DigimonResponse;
            
            int count = digimonResult.Split("name").Length - 1;
            Assert.That(count, Is.EqualTo(209));
        }
    }
}
