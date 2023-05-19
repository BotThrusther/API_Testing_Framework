using APIClientApp.PostcodeIOService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITestApp
{
    [Category("Happy")]
    public class WhenTheDigimonNameServiceIsCalled_WithValidName
    {
        private DigimonService _dms;
        
        [OneTimeSetUp]
        public async Task OneSetUpAsync()
        {
            _dms = new DigimonService();
            await _dms.MakeRequestAsync("name/agumon");
        }

        [Test]
        public void StatusIs200_InHeader()
        {
            Assert.That((int)_dms.CallManager.DigimonResponse.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public void ConnectionIsKeepAlive()
        {
            var result = _dms.GetHeaderValue("Connection");

            Assert.That(result, Is.EqualTo("keep-alive"));
        }
    }
}
