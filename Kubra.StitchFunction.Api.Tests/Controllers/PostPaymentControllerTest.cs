using Kubra.Common.Stitch.Models;
using Kubra.StitchFunction.Api.Controllers;
using Kubra.StitchFunction.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Kubra.StitchFunction.Api.Tests.Controllers
{
    public class PostPaymentControllerTest
    {
        private readonly Mock<IPostPaymentService> paymentServiceMock = new();

        [Fact]
        public async void PostPayment_Returns200()
        {
            //Arrange
            var paymentRequest = new PaymentPostingRequest
            {
                MessageValue = new MessageValue
                {
                    PaymentId = "123"
                }
            };
            paymentServiceMock.Setup(x => x.PostPayment(paymentRequest.MessageValue)).ReturnsAsync(true);

            //Act
            var paymentController = new PaymentController(paymentServiceMock.Object);
            var paymentResult = await paymentController.PostPayment(paymentRequest);
            var statusResult = paymentResult.Result as OkObjectResult;

            //Assert
            Assert.Equal(200, statusResult!.StatusCode!.Value);
        }

        [Fact]
        public async void PostPayment_Returns500()
        {
            //Arrange
            var paymentRequest = new PaymentPostingRequest
            {
                MessageValue = new MessageValue
                {
                    PaymentId = "123",
                    Account = new Account
                    {
                        AccountNumber = "123"
                    }
                }
            };
            paymentServiceMock.Setup(x => x.PostPayment(paymentRequest.MessageValue)).ReturnsAsync(false);

            //Act
            var paymentController = new PaymentController(paymentServiceMock.Object);
            var paymentResult = await paymentController.PostPayment(paymentRequest);
            var result = paymentResult.Result as StatusCodeResult;

            //Assert
            Assert.Equal(500, result!.StatusCode);
        }

        [Fact]
        public void PostPayment_ConstructorThrowsArgumentNullException()
        {
            //Arrange
            
            //Act

            //Assert
            Assert.Throws<ArgumentNullException>(() => new PaymentController(null));
        }
    }
}
