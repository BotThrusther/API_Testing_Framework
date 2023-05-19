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
            var singlePostcodeRequest = new HttpRequestMessage()
            {
                //set request method to get
                Method = HttpMethod.Get
            };
            // Add accept header to HTTP request, so API knows we are expecting a JSON
            singlePostcodeRequest.Headers.Add("Accept", "application/json");
            var postcode = "EC2Y 5AS";
            // Setting up the request URI
            singlePostcodeRequest.RequestUri = new Uri($"https://api.postcodes.io/postcodes/{postcode}");
            HttpResponseMessage singlePostcodeResponse = await client.SendAsync(singlePostcodeRequest);
            Console.WriteLine(singlePostcodeResponse.StatusCode);
            Console.WriteLine((int)singlePostcodeResponse.StatusCode);
        }
    }
}