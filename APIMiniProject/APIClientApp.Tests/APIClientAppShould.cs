using APIClientApp.PostcodeIOService.HTTPManager;
using Moq;
using System.Security.Cryptography.X509Certificates;
using APIClientApp.PostcodeIOService;
using System.Text.Json.Nodes;
using APIClientApp.PostcodeIOService.DataHandling;
using System.Net.Http.Headers;

namespace APIClientApp.Tests
{
    public class APIClientAppShould
    {

        #region APIClientShould DigimonApi Response

        private static string _testDataLocation = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\TestData\");
        [Test]
        public async Task ReturnCorrectStatusCode_WhenStatusCodeMethodIsCalled()
        {
            var mockCallManager = new Mock<ICallManager>();

            mockCallManager
                .Setup(c => c.DigimonResponse)
                .Returns(new HttpResponseMessage { StatusCode = System.Net.HttpStatusCode.OK });
            mockCallManager
                .Setup(x => x.MakeRequestAsync(It.IsAny<string>()))
                .ReturnsAsync("{\"key\":\"value\"}");

            var spcs = new DigimonService(mockCallManager.Object);
            await spcs.MakeRequestAsync(It.IsAny<string>());

            Assert.That(spcs.GetStatusCode(), Is.EqualTo(200));
        }
        [Test]
        public async Task ReturnsCorrectHeaderValue_WhenGetHeadersIsCalled()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            response.Headers.Add("Connection", "keep-alive");

            var mockCallManager = new Mock<ICallManager>();

            mockCallManager
                .Setup(x => x.DigimonResponse)
                .Returns(response);
            mockCallManager
                .Setup(x => x.MakeRequestAsync(It.IsAny<string>()))
                .ReturnsAsync("{\"key\":\"value\"}");

            var spcs = new DigimonService(mockCallManager.Object);
            await spcs.MakeRequestAsync(It.IsAny<string>());

            var result = spcs.GetHeaderValue("Connection");
            Assert.That(result, Is.EqualTo("keep-alive"));
        }

        [Test]
        public async Task ReturnCorrectContentType_WhenGetResponseContentTypeIsCalled()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var mockCallManager = new Mock<ICallManager>();

            mockCallManager
                .Setup(x => x.DigimonResponse)
                .Returns(response);
            mockCallManager
                .Setup(x => x.MakeRequestAsync(It.IsAny<string>()))
                .ReturnsAsync("{\"key\":\"value\"}");

            var spcs = new DigimonService(mockCallManager.Object);
            await spcs.MakeRequestAsync(It.IsAny<string>());

            var result = spcs.GetResponseContentType();
            Assert.That(result, Is.EqualTo("application/json"));
        }
        #endregion
    }
}