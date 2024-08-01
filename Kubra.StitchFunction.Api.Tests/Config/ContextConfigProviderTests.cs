using Kubra.Common.Stitch.Services;
using Kubra.StitchFunction.Api.Config;
using Moq;

namespace Kubra.StitchFunction.Api.Tests.Config
{
    public class ContextConfigProviderTests
    {
        [Fact]
        public void GetConfig_ThrowsArgumentNullException()
        {
            //Arrange

            //Act

            //Assert
            Assert.Throws<ArgumentNullException>(() => new ContextConfigProvider(null));
        }

        [Fact]
        public async void GetConfig_ReturnsClientConfig()
        {
            //Arrange
            Mock<IStitchSecretsService> sidecarServiceMock = new();
            var url = "http://someurl";
            sidecarServiceMock.Setup(s => s.GetContext()).ReturnsAsync("{\"WebServiceUrl\": \"" + url + "\"}");
            var sidecarConfigProvider = new ContextConfigProvider(sidecarServiceMock.Object);

            //Act
            var actual = await sidecarConfigProvider.GetConfig();

            //Assert
            Assert.IsAssignableFrom<IClientConfig>(actual);
            Assert.Equal(actual.WebServiceUrl, url);
        }
    }
}
