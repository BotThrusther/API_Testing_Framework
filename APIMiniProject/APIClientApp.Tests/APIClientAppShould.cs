using APIClientApp.PostcodeIOService.HTTPManager;
using Moq;
using System.Security.Cryptography.X509Certificates;
using APIClientApp.PostcodeIOService;
using System.Text.Json.Nodes;
using APIClientApp.PostcodeIOService.DataHandling;

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

            var spcs = new DigimonService(mockCallManager.Object);
            await spcs.MakeRequestAsync(It.IsAny<string>());

            Assert.That(spcs.GetStatusCode(), Is.EqualTo(200));
        }
        [Test]
        [Ignore("Not Implemented")]
        public async Task ReturnsCorrectNumberOfCodesFromJsonResponse_WhenCodeCountIsCalled()
        {
            //var mockCallManager = new Mock<ICallManager>();

            //mockCallManager
            //    .Setup(c => c.TronaldDumpResponse)
            //    .Returns(It.IsAny<HttpResponseMessage>());

            //mockCallManager
            //    .Setup(x => x.MakeRequestAsync(It.IsAny<string>()))
            //    .ReturnsAsync(File.ReadAllText(_testDataLocation + "SuccessfulSinglePostcodeResponse.json"));
            //var spcs = new TronalDumpService(mockCallManager.Object);
            //await spcs.MakeRequestAsync(It.IsAny<string>());

            //Assert.That(spcs.CodeCount(), Is.EqualTo(13));
        }
        [Test]
        [Ignore("Not Implemented")]
        public async Task ReturnsCorrectHeaderValue_WhenGetHeadersIsCalled()
        {
            //string expectedValue = "testValue";
            //var headers = new List<HeaderParameter>
            //{
            //        new HeaderParameter ("header1", "value1" ),
            //        new HeaderParameter ("header2", expectedValue )
            //};

            //var mockCallManager = new Mock<ICallManager>();

            //// RestResponse StatusCode property set to OK status code
            //mockCallManager
            //    .Setup(x => x.TronaldDumpResponse)
            //    .Returns(new HttpResponseMessage { Headers = headers });

            //mockCallManager
            //    .Setup(x => x.MakeRequestAsync(It.IsAny<string>()))
            //    .ReturnsAsync("{\"key\":\"value\"}");

            //var spcs = new TronalDumpService(mockCallManager.Object);
            //await spcs.MakeRequestAsync(It.IsAny<string>());
            //Assert.That(spcs.GetHeaderValue("header2"), Is.EqualTo(expectedValue));
        }

        [Test]
        [Ignore("Not Implemented")]
        public async Task ReturnCorrectContentType_WhenGetResponseContentTypeIsCalled()
        {
            //var mockCallManager = new Mock<ICallManager>();

            //mockCallManager
            //    .Setup(x => x.TronaldDumpResponse)
            //    .Returns(new HttpResponseMessage { Content = "application/json" });

            //mockCallManager
            //    .Setup(x => x.MakeRequestAsync(It.IsAny<string>()))
            //    .ReturnsAsync("{\"key\":\"value\"}");

            //var spcs = new TronalDumpService(mockCallManager.Object);
            //await spcs.MakeRequestAsync(It.IsAny<string>());
            //Assert.That(spcs.GetResponseContentType(), Is.EqualTo("application/json"));
        }
        #endregion
    }
}