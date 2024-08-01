using Kubra.StitchFunction.Api.Config;
using Kubra.StitchFunction.Api.Services;
using Moq;
using Moq.Protected;
using System.Net;
using System.Text.Json;
using Kubra.Common.Stitch.Models;

namespace Kubra.StitchFunction.Api.Tests.Services
{
    public class RestBalanceServiceTest
    {
        Mock<IClientConfigProvider> _configProvider = new();
        [Fact]
        public async Task GetBalance_Returns200StitchBalance()
        {
            //Arrange
            var response = new StitchBalanceResponse
            {
                CurrentAmountDue = 25.00m,
                DueDate = DateTime.Parse("2023-02-10"),
                LastUpdatedAtSourceDate = DateTime.Parse("2023-02-10")
            };
            var httpClient = GetMockedHttpClient(HttpStatusCode.OK, response);

            var mockFactory = new Mock<IHttpClientFactory>();
            mockFactory.Setup(s => s.CreateClient(It.IsAny<string>())).Returns(httpClient);
            _configProvider.Setup(c => c.GetConfig()).ReturnsAsync(new ClientConfig
            {
                WebServiceUrl = "http://balanceurl"
            });
            var clientApiConfig = _configProvider.Object;
           
            var balanceService = new RestBalanceService(mockFactory.Object, clientApiConfig);

            var expectedResponse = new StitchBalanceResponse
            {
                CurrentAmountDue = 25.00m,
                DueDate = DateTime.Parse("2023-02-10"),
                LastUpdatedAtSourceDate = DateTime.Parse("2023-02-10")
            };

            //Act
            var actualResponse = await balanceService.GetBalance("1");

            //Assert
            Assert.Equal(expectedResponse, actualResponse);
        }

        [Fact]
        public async Task GetBalance_ThrowsDeserializationException()
        {
            //Arrange
            var response = new
            {
                SomeValue = "hello",
                AnotherValue = 2
            };
            var httpClient = GetMockedHttpClient(HttpStatusCode.OK, response);

            var mockFactory = new Mock<IHttpClientFactory>();
            mockFactory.Setup(s => s.CreateClient(It.IsAny<string>())).Returns(httpClient);
            _configProvider.Setup(c => c.GetConfig()).ReturnsAsync(new ClientConfig
            {
                WebServiceUrl = "http://balanceurl"
            });
            var clientApiConfig = _configProvider.Object;

            var balanceService = new RestBalanceService(mockFactory.Object, clientApiConfig);

            //Act

            //Assert
            await Assert.ThrowsAsync<JsonException>(() => balanceService.GetBalance("1"));
        }

        [Fact]
        public async Task GetBalance_ReturnsNullOn204()
        {
            //Arrange
            var httpClient = GetMockedHttpClient(HttpStatusCode.NoContent, null);

            var mockFactory = new Mock<IHttpClientFactory>();
            mockFactory.Setup(s => s.CreateClient(It.IsAny<string>())).Returns(httpClient);
            _configProvider.Setup(c => c.GetConfig()).ReturnsAsync(new ClientConfig
            {
                WebServiceUrl = "http://balanceurl"
            });
            var clientApiConfig = _configProvider.Object;

            var balanceService = new RestBalanceService(mockFactory.Object, clientApiConfig);

            //Act
            var actualResponse = await balanceService.GetBalance("1");

            //Assert
            Assert.Null(actualResponse);
        }

        [Fact]
        public async Task GetBalance_ReturnsNullOn404()
        {
            //Arrange
            var httpClient = GetMockedHttpClient(HttpStatusCode.NotFound, null);

            var mockFactory = new Mock<IHttpClientFactory>();
            mockFactory.Setup(s => s.CreateClient(It.IsAny<string>())).Returns(httpClient);
            _configProvider.Setup(c => c.GetConfig()).ReturnsAsync(new ClientConfig
            {
                WebServiceUrl = "http://balanceurl"
            });
            var clientApiConfig = _configProvider.Object;

            var balanceService = new RestBalanceService(mockFactory.Object, clientApiConfig);

            //Act
            var actualResponse = await balanceService.GetBalance("1");

            //Assert
            Assert.Null(actualResponse);
        }

        [Fact]
        public async Task GetBalance_ThrowsHttpRequestExceptionOnUnexepectedResponse()
        {
            //Arrange
            var httpClient = GetMockedHttpClient(HttpStatusCode.BadRequest, null);

            var mockFactory = new Mock<IHttpClientFactory>();
            mockFactory.Setup(s => s.CreateClient(It.IsAny<string>())).Returns(httpClient);
            _configProvider.Setup(c => c.GetConfig()).ReturnsAsync(new ClientConfig
            {
                WebServiceUrl = "http://balanceurl"
            });
            var clientApiConfig = _configProvider.Object;

            var balanceService = new RestBalanceService(mockFactory.Object, clientApiConfig);

            //Act

            //Assert
            await Assert.ThrowsAsync<HttpRequestException>(() => balanceService.GetBalance("1"));
        }

        [Fact]
        public void GetBalance_ThrowsNullArgumentExceptionWithNullApiConfig()
        {
            //Arrange
            var httpClient = GetMockedHttpClient(HttpStatusCode.BadRequest, null);
            var mockFactory = new Mock<IHttpClientFactory>();
            mockFactory.Setup(s => s.CreateClient(It.IsAny<string>())).Returns(httpClient);

            //Act

            //Assert
            Assert.Throws<ArgumentNullException>(() => new RestBalanceService(mockFactory.Object, null));
        }

        [Fact]
        public void GetBalance_ThrowsNullArgumentExceptionWithNullHttpClient()
        {
            //Arrange

            //Act

            //Assert
            Assert.Throws<ArgumentNullException>(() => new RestBalanceService(null, _configProvider.Object));
        }

        private HttpClient GetMockedHttpClient(HttpStatusCode statusCode, object? content)
        {
            
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = statusCode,
                        Content = content is not null ? new StringContent(JsonSerializer.Serialize(content,
                            new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase })) : null
                    }
                );

            return new HttpClient(mockHttpMessageHandler.Object);
        }
    }
}
