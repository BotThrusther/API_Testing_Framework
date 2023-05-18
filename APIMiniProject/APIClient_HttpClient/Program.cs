using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace APIClient_HttpClient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using (var client = new HttpClient())
            {
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

                try 
                {
                    HttpResponseMessage singlePostcodeResponse = await client.SendAsync(singlePostcodeRequest);
                    Console.WriteLine("Status codes");
                    Console.WriteLine(singlePostcodeResponse.StatusCode);
                    Console.WriteLine((int)singlePostcodeResponse.StatusCode);

                    if(singlePostcodeResponse.IsSuccessStatusCode)
                    {
                        string singlPostcodeContent = await singlePostcodeResponse.Content.ReadAsStringAsync();
                        await Console.Out.WriteLineAsync("\nSingle postcode response body content");
                        await Console.Out.WriteLineAsync(singlPostcodeContent);
                        // Assign Headers
                        HttpHeaders singlePostcodeHeaders = singlePostcodeResponse.Headers;
                        Console.WriteLine("\nSingle Postcode Reasponse Headers");
                        Console.WriteLine(singlePostcodeHeaders);
                        // Check date header
                        string dateHeader = singlePostcodeHeaders.GetValues("Date").FirstOrDefault();
                        Console.WriteLine(dateHeader);


                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("error" + ex.Message );
                }
            }

            var bulkClient = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post
            };
            request.Headers.Add("Accept", "application/json");
            var postcodes = new
            {
                postcodes = new string[] { "OX49 5NU", "M32 0JG", "NE30 1DP" }
            };
            var postcodesJson = JsonConvert.SerializeObject(postcodes);
            request.Content = new StringContent(postcodesJson, Encoding.UTF8, "application/json");
            request.RequestUri = new Uri(@$"https://api.postcodes.io/postcodes/");

            HttpResponseMessage bulkPostcodeResponse = await bulkClient.SendAsync(request);
            Console.WriteLine("Status codes");
            Console.WriteLine(bulkPostcodeResponse.StatusCode);
            Console.WriteLine((int)bulkPostcodeResponse.StatusCode);

            string bulkPostcodeContent = await bulkPostcodeResponse.Content.ReadAsStringAsync();
            Console.WriteLine("\nBulk postcode response body content");
            Console.WriteLine(bulkPostcodeContent);
            bulkClient.Dispose();
        }
    }
}