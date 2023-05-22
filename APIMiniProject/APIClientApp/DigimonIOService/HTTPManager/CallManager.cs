using APIClientApp.PostcodeIOService.DataHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using System.Net.Http.Json;

namespace APIClientApp.PostcodeIOService.HTTPManager
{
    public class CallManager : ICallManager
    {
        private readonly HttpClient _client;
        private readonly string _baseUri;
        public HttpResponseMessage DigimonResponse { get; set; }
        public CallManager()
        {
            _client = new HttpClient();
            _baseUri = AppConfigReader.BaseUrl;
        }

        public async Task<string> MakeRequestAsync(string callTag)
        {
            var request = new HttpRequestMessage();
            request.Headers.Add("Accept", "application/json");
            request.RequestUri = new Uri($"{_baseUri}{callTag}");
            DigimonResponse = await _client.SendAsync(request);
            return await DigimonResponse.Content.ReadAsStringAsync();
        }
    }
}
