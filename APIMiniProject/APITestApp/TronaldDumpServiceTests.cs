using APIClientApp.PostcodeIOService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITestApp
{
    [Category("Happy")]
    internal class WhenTheSinglePostcdeServiceIsCalled_WithValidPostcode
    {
        private TronalDumpService _tds;
        
        [OneTimeSetUp]
        public async Task OneSetUpAsync()
        {
            _tds = new TronalDumpService();
            await _tds.MakeRequestAsync("");
        }

        [Test]
        public void StatusIs200_InJsonResponseBody()
        {
            Assert.That(_tds.JsonResponse["status"].ToString(), Is.EqualTo("200"));
        }

        [Test]
        public void StatusIs200_InHeader()
        {
            Assert.That(_tds.GetStatusCode(), Is.EqualTo(200));
        }

        [Test]
        public void ContentType_IsJson()
        {
            Assert.That(_tds.GetResponseContentType(), Is.EqualTo("application/json"));
        }

        [Test]
        public void ConnectionIsKeepAlive()
        {
            var result = _tds.GetHeaderValue("Connection");

            Assert.That(result, Is.EqualTo("keep-alive"));
        }

        [Test]
        public void ObjectStatusIs200()
        {
            var result  = _tds.TronaldDumpDTO.Response.status;
            Assert.That(result, Is.EqualTo(200));
        }

        [Test]
        public void StatusInReponseHeader_SameAsStatusInResponseBody()
        {
            Assert.That((int)_tds.CallManager.TronaldDumpResponse.StatusCode, Is.EqualTo(_tds.TronaldDumpDTO.Response.status));
        }

        [Test]
        [Ignore("Not Implemented")]
        public void NumberOfCode_IsCorrect()
        {
            Assert.That(_tds.CodeCount(), Is.EqualTo(13));
        }

    }
}
