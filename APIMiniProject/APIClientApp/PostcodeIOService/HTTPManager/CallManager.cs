using APIClientApp.PostcodeIOService.DataHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace APIClientApp.PostcodeIOService.HTTPManager
{
    public class CallManager : ICallManager
    {
        private readonly HttpClient _client;
        private readonly string _baseUri;
        public HttpResponseMessage TronaldDumpResponse { get; set; }
        public CallManager()
        {
            _client = new HttpClient();
            _baseUri = "https://docs.tronalddump.io/";
        }

        public async Task<string> MakeRequestAsync(string callTag)
        {
            var request = new HttpRequestMessage();
            request.Headers.Add("Content-Type", "application/json");
            request.RequestUri = new Uri($"{_baseUri}{callTag}");
            TronaldDumpResponse = await _client.SendAsync(request);
            return await TronaldDumpResponse.Content.ReadAsStringAsync();
        }
    }
}
