using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIClientApp.PostcodeIOService.HTTPManager
{
    public interface ICallManager
    {
        public HttpResponseMessage TronaldDumpResponse { get; set; }
        public Task<string> MakeRequestAsync(string postcode);
    }
}
