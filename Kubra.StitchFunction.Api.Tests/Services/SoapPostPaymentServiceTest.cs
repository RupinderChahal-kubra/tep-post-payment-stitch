using System.ServiceModel;
using Kubra.Common.Stitch.Models;
using Kubra.StitchFunction.Api.Services;
using MockClientSOAPService;
using Moq;

namespace Kubra.StitchFunction.Api.Tests.Services
{
    public class SoapPostPaymentServiceTest
    {
        private Mock<ISoapService> _mockSoapService = new();

        [Fact]
        public void PostPayment_ThrowsNullArgumentException()
        {
            //Arrange

            //Act

            //Assert
            Assert.Throws<ArgumentNullException>(() => new SoapPostPaymentService(null));
        }

        [Fact]
        public async void PostPayment_ThrowsExceptionOnNull()
        {
            //Arrange
            _mockSoapService.Setup(s => s.PostPaymentAsync(It.IsAny<PostPaymentRequest>())).ReturnsAsync(new PostPaymentResponse());

            //Act
            var postPaymentService = new SoapPostPaymentService(_mockSoapService.Object);

            //Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await postPaymentService.PostPayment(new MessageValue()));
        }

        [Fact]
        public async void PostPayment_ReturnsTrueOnValidResponse()
        {
            //Arrange
            _mockSoapService.Setup(s => s.PostPaymentAsync(It.IsAny<PostPaymentRequest>())).ReturnsAsync(GetSoapPostPaymentResponse());

            //Act
            var postPaymentService = new SoapPostPaymentService(_mockSoapService.Object);
            var response = await postPaymentService.PostPayment(new MessageValue());

            //Assert
            Assert.True(response);
        }

        private PostPaymentResponse GetSoapPostPaymentResponse()
        {
            return new PostPaymentResponse(new PostPaymentResponseBody(true));

        }

    }
}
