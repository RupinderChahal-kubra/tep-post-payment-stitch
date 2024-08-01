using Kubra.StitchFunction.Api.Config;
using Kubra.StitchFunction.Api.Services;
using Moq;
using Moq.Protected;
using System.Net;
using Kubra.Common.Stitch.Models;

namespace Kubra.StitchFunction.Api.Tests.Services
{
    public class RestPostPaymentServiceTest
    {
        Mock<IClientConfigProvider> _configProvider = new();
        [Fact]
        public async Task PostPayment_ReturnsTrue()
        {
            //Arrange
            var httpClient = GetMockedHttpClient(HttpStatusCode.OK);

            var mockFactory = new Mock<IHttpClientFactory>();
            mockFactory.Setup(s => s.CreateClient(It.IsAny<string>())).Returns(httpClient);
            _configProvider.Setup(c => c.GetConfig()).ReturnsAsync(new ClientConfig
            {
                WebServiceUrl = "http://paymentpostingurl"
            });
            var clientApiConfig = _configProvider.Object;
            var postPaymentService = new RestPostPaymentService(mockFactory.Object, clientApiConfig);

            //Act
            var actualResponse = await postPaymentService.PostPayment(GetPostPaymentRequest());

            //Assert
            Assert.True(actualResponse);
        }

        [Fact]
        public async Task PostPayment_ThrowsHttpRequestException()
        {
            //Arrange
            var httpClient = GetMockedHttpClient(HttpStatusCode.BadRequest);

            var mockFactory = new Mock<IHttpClientFactory>();
            mockFactory.Setup(s => s.CreateClient(It.IsAny<string>())).Returns(httpClient);
            _configProvider.Setup(c => c.GetConfig()).ReturnsAsync(new ClientConfig
            {
                WebServiceUrl = "http://paymentpostingurl"
            });
            var clientApiConfig = _configProvider.Object;
            var postPaymentService = new RestPostPaymentService(mockFactory.Object, clientApiConfig);

            //Act

            //Assert
            await Assert.ThrowsAsync<HttpRequestException>(() => postPaymentService.PostPayment(GetPostPaymentRequest()));
        }

        [Fact]
        public void PostPayment_ThrowsArgumentNullExceptionOnNullHttpClient()
        {
            //Arrange

            //Act

            //Assert
            Assert.Throws<ArgumentNullException>(() => new RestPostPaymentService(null, _configProvider.Object));
        }

        [Fact]
        public void PostPayment_ThrowsArgumentNullExceptionOnNullApiConfig()
        {
            //Arrange
            var httpClient = GetMockedHttpClient(HttpStatusCode.BadRequest);

            var mockFactory = new Mock<IHttpClientFactory>();
            mockFactory.Setup(s => s.CreateClient(It.IsAny<string>())).Returns(httpClient);

            //Act

            //Assert
            Assert.Throws<ArgumentNullException>(() => new RestPostPaymentService(mockFactory.Object, null));
            Assert.Throws<ArgumentNullException>(() => new RestPostPaymentService(null, _configProvider.Object));
        }

        public MessageValue GetPostPaymentRequest()
        {
            return new MessageValue
            {
                PaymentId = "123"
            };
        }

        private HttpClient GetMockedHttpClient(HttpStatusCode statusCode)
        {
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = statusCode
                    }
                );

            return new HttpClient(mockHttpMessageHandler.Object);
        }
    }
}
