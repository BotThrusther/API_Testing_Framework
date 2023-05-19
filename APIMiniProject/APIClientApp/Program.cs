using APIClientApp.PostcodeIOService.DataHandling;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace APIClientApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient();
            // Set up the request
            var digimonLevelRequest = new HttpRequestMessage()
            {
                //set request method to get
                Method = HttpMethod.Get
            };
            // Add accept header to HTTP request, so API knows we are expecting a JSON
            digimonLevelRequest.Headers.Add("Accept", "application/json");
            var levelRequest = "name/agumon";
            // Setting up the request URI
            digimonLevelRequest.RequestUri = new Uri($"https://digimon-api.vercel.app/api/digimon/{levelRequest}");
            HttpResponseMessage digimonLevelResponse = await client.SendAsync(digimonLevelRequest);
            Console.WriteLine(digimonLevelResponse.StatusCode);
            Console.WriteLine((int)digimonLevelResponse.StatusCode);
        }
    }
}