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
    public class DigimonService
    {
        #region Properties
        public ICallManager CallManager { get; set; }
        public string DigimonResponse { get; set; }
        #endregion

        public DigimonService(ICallManager callManager = null)
        {
            CallManager = callManager is null ? new CallManager() : callManager;
        }

        public async Task MakeRequestAsync(string callTag)
        {
            DigimonResponse = await CallManager.MakeRequestAsync(callTag);
        }

        public int GetStatusCode()
        {
            return (int)CallManager.DigimonResponse.StatusCode;
        }

        public string GetHeaderValue(string name)
        {
            return CallManager.DigimonResponse.Headers.GetValues(name).FirstOrDefault();
        }

        public string GetResponseContentType()
        {
            
            return CallManager.DigimonResponse.Content.Headers.ContentType.ToString();
        }
    }
}
