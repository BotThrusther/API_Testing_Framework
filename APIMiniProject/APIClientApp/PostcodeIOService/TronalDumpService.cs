using APIClientApp.PostcodeIOService.DataHandling;
using APIClientApp.PostcodeIOService.HTTPManager;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIClientApp.PostcodeIOService
{
    public class TronalDumpService
    {
        #region Properties
        public ICallManager CallManager { get; set; }
        public JObject JsonResponse { get; set; }
        public string PostcodeReponse { get; set; }
        public DTO<TronaldDumpResponse> TronaldDumpDTO { get; set; }
        #endregion

        public TronalDumpService(ICallManager callManager = null)
        {
            CallManager = callManager is null ? new CallManager() : callManager;
            TronaldDumpDTO = new DTO<TronaldDumpResponse>();
        }

        public async Task MakeRequestAsync(string callTag)
        {
            PostcodeReponse = await CallManager.MakeRequestAsync(callTag);
            JsonResponse = JObject.Parse(PostcodeReponse);
            TronaldDumpDTO.DeserializeResponse(PostcodeReponse);
        }

        public int GetStatusCode()
        {
            return (int)CallManager.TronaldDumpResponse.StatusCode;
        }

        public string GetHeaderValue(string name)
        {
            return CallManager.TronaldDumpResponse.Headers.GetValues(name).FirstOrDefault();
        }

        public string GetResponseContentType()
        {
            return GetHeaderValue("Content-Type");
        }

        public int CodeCount()
        {
            var count = 0;
            foreach (var code in JsonResponse["result"]["codes"])
            {
                count++;
            }

            return count;
        }
    }
}
